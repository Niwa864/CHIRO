using UnityEngine;
using UnityEngine.SceneManagement;

public class Bubble : MonoBehaviour {

    static int nFrameInt;
    static int nFrameFloat;
    static float fTime;
    static int nTime;
    static bool bOnce;
    static bool bOnceFloat;
    static bool bEnd;
    static bool bEndOnce;
    static int nCnt;
    static int nCntEnd;

	// Use this for initialization
	void Start () {
        nFrameInt = 0;
        nFrameFloat = 0;
        nTime = 0;
        fTime = 0.0f;
        nCnt = 6;
        bOnce = false;
        bEnd = false;
        bOnceFloat = false;
        bEndOnce = true;
        nCntEnd = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Fade.bReturn == true) return;

        nFrameInt++;
        nFrameFloat++;

        if (nFrameFloat >= 60 * 6 / 10)
        {
            fTime += 0.1f;
            bOnceFloat = true;
            nFrameFloat = 0;
        }

        if (nFrameInt >= 60 * 6)
        {
            nTime ++;
            bOnce = true;
            nFrameInt = 0;
        }

        if (bOnceFloat == true)
        {
            if (fTime >= 60.4)
                GameObject.Find("Bubble1").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            else if (fTime >= 50.4)
                GameObject.Find("Bubble2").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            else if (fTime >= 40.4)
                GameObject.Find("Bubble3").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            else if (fTime >= 30.4)
                GameObject.Find("Bubble4").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            else if (fTime >= 20.4)
                GameObject.Find("Bubble5").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            else if (fTime >= 10.4)
                GameObject.Find("Bubble6").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            bOnceFloat = false;
        }

        if (bOnce == true)
        {
            SetScale();

            SetBlow();

            bOnce = false;
        }

        if (bEnd == true)
            nCntEnd++;

        if (nCntEnd > 60 * 6)
        {
            if (bEndOnce == true)
            {
                Fade.Stage = "Main5";
                FailKitune.nUsagi = Blocks.nNum;
                SceneManager.LoadScene("Stage5Fail", LoadSceneMode.Additive);
                Fade.bReturn = true;
                if (StageTouch.bClear[4] == false)
                    StageTouch.bClear[4] = false;
                Blocks.nCount = 0;

                bEndOnce = false;
            }
        }
    }

    private void SetBlow()
    {
        switch (nTime)
        {

            case 60:
                GameObject.Find("Bubble1").GetComponent<Animator>().SetTrigger("Blow");
                bEnd = true;
                break;

            case 50:
                GameObject.Find("Bubble2").GetComponent<Animator>().SetTrigger("Blow");
                break;

            case 40:
                GameObject.Find("Bubble3").GetComponent<Animator>().SetTrigger("Blow");
                break;

            case 30:
                GameObject.Find("Bubble4").GetComponent<Animator>().SetTrigger("Blow");
                break;

            case 20:
                GameObject.Find("Bubble5").GetComponent<Animator>().SetTrigger("Blow");
                nCnt--;
                break;

            case 10:
                GameObject.Find("Bubble6").GetComponent<Animator>().SetTrigger("Blow");
                break;
        }

    }

    private void SetScale()
    {
        if (nCnt == 0) return;
        if (nTime >= 59) return;
        switch (nTime % nCnt + 1)
        {
            case 1:
                    GameObject.Find("Bubble1").GetComponent<Animator>().SetTrigger("Scale");

                break;

            case 2:
                    GameObject.Find("Bubble2").GetComponent<Animator>().SetTrigger("Scale");
                break;

            case 3:
                    GameObject.Find("Bubble3").GetComponent<Animator>().SetTrigger("Scale");
                break;

            case 4:
                    GameObject.Find("Bubble4").GetComponent<Animator>().SetTrigger("Scale");
                break;

            case 5:
                    GameObject.Find("Bubble5").GetComponent<Animator>().SetTrigger("Scale");
                break;

            case 6:
                    GameObject.Find("Bubble6").GetComponent<Animator>().SetTrigger("Scale");
                break;
        }
    }
}
