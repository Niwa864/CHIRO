using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGear : MonoBehaviour {

    private int nCnt;

	// Use this for initialization
	void Start () {
        nCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {


        if (Fade.nAlfa == 1 && this.gameObject.name == "FadeRight")
        {
            if (this.transform.position.x > 17.0f + 19.0f)
                Fade.nAlfa = 2;
            else
                this.transform.position += new Vector3(1.0f, 0.0f);
        }

        if (Fade.nAlfa == 0 && this.gameObject.name == "FadeRight")
        {
            if (this.transform.position.x <= 18.0f)
            {
                nCnt++;
                if (nCnt > 30)
                    Fade.nAlfa = 1;
            }
            else
                this.transform.position -= new Vector3(1.0f, 0.0f);  
        }

        if (Fade.nAlfa == 1 && this.gameObject.name == "FadeLeft")
        {
            if (this.transform.position.x < -17.0f - 19.0f)
                Fade.nAlfa = 2;
            else
                this.transform.position -= new Vector3(1.0f, 0.0f);
        }

        if (Fade.nAlfa == 0 && this.gameObject.name == "FadeLeft")
        {
            if (this.transform.position.x >= -18.0f)
            {
                nCnt ++;
                if(nCnt > 30)
                    Fade.nAlfa = 1;
            }
            else
                this.transform.position += new Vector3(1.0f, 0.0f);       
        }
	}
}
