using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public Sprite Word;
    GameObject Player;
    float fDeltaTime;
    Vector3 EnemyPos;
    Animator PlayerAnim;
    public static string sReturnStage;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("TimePlayer");
        PlayerAnim = GameObject.Find("TimePlayer").GetComponent<Animator>();
        EnemyPos = transform.position;
        fDeltaTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Fade.nAlfa != 2) return;
        if (Go.bMove == false) return;  

        if (Blocks.bClear == true)
        {
            GetComponent<Animator>().SetTrigger("Stop");
            return;
        }
        if (Pause.bStop == true) return;
        if (fDeltaTime <= 60.0f)
            fDeltaTime += Time.deltaTime;

        Leap(EnemyPos.x, EnemyPos.y, Player.GetComponent<Transform>().transform.position.x, 
            Player.GetComponent<Transform>().transform.position.y, 60.0f, fDeltaTime);

        if (fDeltaTime > 20 && fDeltaTime < 40)
        {
            PlayerAnim.SetTrigger("Well");
            GameObject.Find("word").GetComponent<SpriteRenderer>().sprite = Word;
            AudioPlayer.bAudio = true;
        }
        else if (fDeltaTime > 40)
        {
            PlayerAnim.SetTrigger("Bad");
        }

	}

    void Leap(float fStartX, float fStartY, float fEndX, float fEndY, float fMax, float fCurrent)
    {
        float foutX = fStartX + (fEndX - fStartX) * ((fCurrent - 0.0f) / (fMax - 0.0f));
        float foutY = fStartY + (fEndY - fStartY) * ((fCurrent - 0.0f) / (fMax - 0.0f));

        if (transform.position.x - 0.1f > foutX)
        {
            transform.position = new Vector3(foutX, foutY);
            GetComponent<Animator>().SetTrigger("Move");
        }                        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "TimePlayer")
        {
            Fade.Stage = sReturnStage;
            FailKitune.nUsagi = Blocks.nNum;
            SceneManager.LoadScene("Fail", LoadSceneMode.Additive);
            Fade.bReturn = true;
            GetStage();
            Blocks.nCount = 0;
            GetComponent<Animator>().SetTrigger("Stop");
        }
    }

    private void GetStage()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Main1":
                if (StageTouch.bClear[0] == false)
                    StageTouch.bClear[0] = false;
                break;
            case "Main2":
                if (StageTouch.bClear[1] == false)
                    StageTouch.bClear[1] = false;
                break;
            case "Main3":
                if (StageTouch.bClear[2] == false)
                    StageTouch.bClear[2] = false;
                break;
            case "Main4":
                if (StageTouch.bClear[3] == false)
                    StageTouch.bClear[3] = false;
                break;
            case "Main5":
                if (StageTouch.bClear[4] == false)
                    StageTouch.bClear[4] = false;
                break;
        }
    }
}
