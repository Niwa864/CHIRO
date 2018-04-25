using UnityEngine;

public class Cloud : MonoBehaviour {
    static int nCount = 0;
    string sStage;
    string sCloud;
    private bool bMove = false;
    private bool bSwitch;
    private float fMoveY;
    static int nCnt;
   private bool bJingle;
    public static bool bCloud1 = false;
    public static bool bCloud2 = false;
    public static bool bCloud3 = false;
    public static bool bCloud4 = false;
    public static bool bCloudAnim;

	// Use this for initialization
	void Start () {
        sCloud = this.gameObject.name;
        ThisCloud();
        sStage = "Stage";
        sStage += nCount.ToString();
        bMove = false;
        bSwitch = false;
        bCloudAnim = false;
        nCnt =  0;
        fMoveY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Fade.nAlfa != 2) return;

        MoveCload();
        CloadAnim();
	}

    private void CloadAnim()
    {
        if (bCloud1 == true && this.gameObject.name == "Cloud1")
        {
            if (!bJingle)
            {
                GetComponent<AudioSource>().Play();
                bJingle = true;
            }
            if (this.GetComponent<SpriteRenderer>().color.a != 1.0f)
            this.GetComponent<Transform>().transform.position -= new Vector3( 0.1f, -0.1f) * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color -= new Color( 0.0f, 0.0f, 0.0f, 0.01f);

            if (this.GetComponent<SpriteRenderer>().color.a <= 0.0f)
                bCloudAnim = false;
        }

        if (bCloud2 == true && this.gameObject.name == "Cloud2")
        {
            if (!bJingle)
            {
                GetComponent<AudioSource>().Play();
                bJingle = true;
            }

            if (this.GetComponent<SpriteRenderer>().color.a != 1.0f)
                this.GetComponent<Transform>().transform.position += new Vector3(0.1f, 0.1f) * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.0f, 0.0f, 0.01f);

            if (this.GetComponent<SpriteRenderer>().color.a <= 0.0f)
                bCloudAnim = false;
        }

        if (bCloud3 == true && this.gameObject.name == "Cloud3")
        {
            if (!bJingle)
            {
                GetComponent<AudioSource>().Play();
                bJingle = true;
            }
            if (this.GetComponent<SpriteRenderer>().color.a != 1.0f)
                this.GetComponent<Transform>().transform.position += new Vector3(0.1f, 0.0f) * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.0f, 0.0f, 0.01f);

            if (this.GetComponent<SpriteRenderer>().color.a <= 0.0f)
                bCloudAnim = false;
        }

        if (bCloud4 == true && this.gameObject.name == "Cloud4")
        {
            if (!bJingle)
            {
                GetComponent<AudioSource>().Play();
                bJingle = true;
            }
            if (this.GetComponent<SpriteRenderer>().color.a != 1.0f)
                this.GetComponent<Transform>().transform.position -= new Vector3( 0.0f, 0.1f) * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color -= new Color(0.0f, 0.0f, 0.0f, 0.01f);

            if (this.GetComponent<SpriteRenderer>().color.a <= 0.0f)
                bCloudAnim = false;
        }
    }

    private void MoveCload()
    {
        nCnt++;

        switch(((nCnt / 4) % 40) + 1)
        {
            case 10:
                if (bMove == false && this.gameObject.name == "Cloud1")
                {
                    bMove = true;

                }
                break;

            case 20:
                if (bMove == false && this.gameObject.name == "Cloud2")
                {
                    bMove = true;
                }
                break;


            case 30:
                if (bMove == false && this.gameObject.name == "Cloud3")
                {
                    bMove = true;
                }
                break;


            case 40:
                if (bMove == false && this.gameObject.name == "Cloud4")
                {
                    bMove = true;
                }
                break;
        }

        if (bMove == true && this.gameObject.name == "Cloud1")
        {
           switch (bSwitch)
            {
                case false:

                    if (fMoveY < 0.1f)
                    {
                        fMoveY += 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                        bSwitch = true;
                    break;

                case true:
                    if (fMoveY > 0.0f && bSwitch == true)
                    {
                        fMoveY -= 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position -= new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                    {
                        bSwitch = false;
                        bMove = false;
                    }

                    break;
            }

        }

        if (bMove == true && this.gameObject.name == "Cloud2")
        {
            switch (bSwitch)
            {
                case false:

                    if (fMoveY < 0.1f)
                    {
                        fMoveY += 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                        bSwitch = true;
                    break;

                case true:
                    if (fMoveY > 0.0f && bSwitch == true)
                    {
                        fMoveY -= 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position -= new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                    {
                        bSwitch = false;
                        bMove = false;
                    }

                    break;
            }
        }

        if (bMove == true && this.gameObject.name == "Cloud3")
        {
            switch (bSwitch)
            {
                case false:

                    if (fMoveY < 0.1f)
                    {
                        fMoveY += 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                        bSwitch = true;
                    break;

                case true:
                    if (fMoveY > 0.0f && bSwitch == true)
                    {
                        fMoveY -= 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position -= new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                    {
                        bSwitch = false;
                        bMove = false;
                    }

                    break;
            }
        }

        if (bMove == true && this.gameObject.name == "Cloud4")
        {
            switch (bSwitch)
            {
                case false:

                    if (fMoveY < 0.1f)
                    {
                        fMoveY += 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                        bSwitch = true;
                    break;

                case true:
                    if (fMoveY > 0.0f && bSwitch == true)
                    {
                        fMoveY -= 0.3f * Time.deltaTime;
                        this.GetComponent<Transform>().transform.position -= new Vector3(0.0f, 0.1f) * Time.deltaTime;
                    }
                    else
                    {
                        bSwitch = false;
                        bMove = false;
                    }

                    break;
            }
        }
    }

    void ThisCloud()
    {
        switch (sCloud)
        {
            case "Cloud1":
                this.transform.position = new Vector3(-2.03f, 0.76f);
                nCount = 1;
                break;
            case "Cloud2":
                this.transform.position = new Vector3(3.11f, 3.31f);
                nCount = 2;
                break;
            case "Cloud3":
                this.transform.position = new Vector3(3.11f, -0.08f);
                nCount = 3;
                break;
            case "Cloud4":
                this.transform.position = new Vector3(-0.18f, -2.29f);
                nCount = 4;
                break;
        }
    }
}
