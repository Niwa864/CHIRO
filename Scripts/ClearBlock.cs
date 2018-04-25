using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBlock : MonoBehaviour {

    static int nCnt;
    private bool bOnce;
    static public bool bStart;

	// Use this for initialization
	void Start () {
        nCnt = 0;
        bOnce = true;
        bStart = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (bStart == false) return;
        if (nCnt / 10 == 10 && this.gameObject.name == "000")
        {
            this.GetComponent<Animator>().SetTrigger("JumpForword");
            if (bOnce == true)
            {
                this.transform.position += new Vector3( 0.0f, 1.0f);
                bOnce = false;
            }
        }
        if (nCnt / 10 == 20 && this.gameObject.name == "000 (1)")
        {
            this.GetComponent<Animator>().SetTrigger("JumpForword");
            if (bOnce == true)
            {
                this.transform.position += new Vector3(0.0f, 1.0f);
                bOnce = false;
            }
        }
        if (nCnt / 10 == 30 && this.gameObject.name == "000 (2)")
        {
            this.GetComponent<Animator>().SetTrigger("JumpForword");
            if (bOnce == true)
            {
                this.transform.position += new Vector3(0.0f, 1.0f);
                bOnce = false;
            }
        }
        if (nCnt / 10 == 40 && this.gameObject.name == "000 (3)")
        {
            this.GetComponent<Animator>().SetTrigger("JumpForword");
            if (bOnce == true)
            {
                this.transform.position += new Vector3(0.0f, 1.0f);
                bOnce = false;
            }
        }

        if (nCnt / 10 == 50)
            nCnt = 0;

        nCnt++;
	}
}
