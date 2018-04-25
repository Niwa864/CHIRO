using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearMove : MonoBehaviour {

    private bool bOnce;
    private Animation anim;
    private int nTime;

	// Use this for initialization
	void Start () {
        nTime = 0;
        bOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 6.5f && nTime < 30)
        {
            this.transform.position -= new Vector3(3.0f, 0.0f) * Time.deltaTime;
        }
        else
        {
            if (nTime == 0)
            {
                GetComponent<Animator>().SetTrigger("Stop");
                
            }

            if (nTime == 180)
            {
                GetComponent<Animator>().SetTrigger("Right");
                ClearBlock.bStart = true;
            }
            else if (nTime > 180)
            {
                this.transform.position += new Vector3(3.0f, 0.0f) * Time.deltaTime;
                if (this.transform.position.x > 16.0f && bOnce == true)
                {
                    Success.bSuccess = true;
                    Fade.ClrFlg = 0;
                    bOnce = false;
                }
            }
            nTime++;
        }

	}
}
