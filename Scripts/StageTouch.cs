using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTouch : MonoBehaviour {

    static public bool[] bClear = { false, false, false, false, false };
    public bool Clear;
    
    private GameObject CameraTouch;
    Camera main;
    private bool bTouch = false;
    private string sTarget;
    private bool bOnce;
    private bool bPopup;
    public static string sStage;

    public Sprite Stage1;
    public Sprite Stage2;
    public Sprite Stage3;
    public Sprite Stage4;
    public Sprite Stage5;

    int i;
    //public static bool bFromMain = false;
    //public static string sMainClear;

	// Use this for initialization
    void Start()
    {
        Clear = bClear[i];
        bTouch = false;
        bOnce = true;
        CameraTouch = GameObject.Find("Touch Camera");
        bPopup = false;
        i++;
	}
	
	// Update is called once per frame
	void Update () {
        
        GetTarget();
        if (Fade.nAlfa != 2) return;
        if (Cloud.bCloudAnim == true) return;
        if (EndAnim.bEndAnim == true) return;
        GetMouse();
        if (bPopup == true)
            if (GameObject.Find("popup").GetComponent<Transform>().localScale.y < 0.5f)
            {
                GameObject.Find("popup").GetComponent<Transform>().localScale += new Vector3(0.0f, 0.02f);
                GameObject.Find("popup").GetComponent<BoxCollider2D>().size += new Vector2(0.2f, 0.2f);
                GameObject.Find("popup").GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.05f);
            }
            else
                bPopup = false;
	}

    void GetMouse()
    {
        main = CameraTouch.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);

        if(this.GetComponent<SpriteRenderer>().color.a != 0)
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (bTouch == true && col != GameObject.Find("popup").GetComponent<Collider2D>() && bPopup == false)
            {
                GameObject.Find("popup").GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 0);
                GameObject.Find("popup").GetComponent<Transform>().localScale = new Vector3( 0.5f, 0.01f);
                GameObject.Find("popup").GetComponent<BoxCollider2D>().size = new Vector2(0.0f, 0.0f);
                bTouch = false;
            }
            else if (bTouch == true && col == GameObject.Find("popup").GetComponent<Collider2D>() && bPopup == false)
            {
                SetStage();
                GameObject.Find("popup").GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 0);
                SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
            }

            if (col == this.GetComponent<Collider2D>() && bPopup == false)
            {
                bTouch = true;
                GameObject.Find("popup").GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 255);
                GameObject.Find("popup").GetComponent<Transform>().position = this.transform.position + new Vector3( -0.1f, 0.0f);
                GameObject.Find("popup").GetComponent<BoxCollider2D>().size = new Vector2(0.0f, 0.0f);
                bPopup = true;
                SetPopUp(this.gameObject.name);
            }
        }
    }

    void  SetStage()
    {
        string sTemp;
        int i;

        for ( i = 1; i <= 13; i++)
        {
            sTemp = "Stage";
            sTemp += i.ToString();

            if (GameObject.Find(sTemp).GetComponent<StageTouch>().bTouch == true)
            {
                //GameObject.Find(sTemp).GetComponent<StageTouch>().bTouch = false;
                break;
            }
        }
        sTemp = "Main";
        sTemp += i.ToString();
        sStage = sTemp;
    }

    void GetTarget()
    {
        switch (this.gameObject.name)
        {
            case "Stage1":
                if (bClear[0] == true)
                {
                    if (bOnce == true)
                    {
                        GameObject.Find("Stage2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                        if (Cloud.bCloud1 == true)
                        {
                            GameObject.Find("Cloud1").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                        }
                        else if (Cloud.bCloud1 == false)
                        {
                            Cloud.bCloud1 = true;
                            Cloud.bCloudAnim = true;
                        }
                            
                        bOnce = false;
                    }

                }
                break;
            case "Stage2":
                if (bClear[1] == true) 
                {
                    if (bOnce == true)
                    {
                        GameObject.Find("Stage3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                        if (Cloud.bCloud2 == true)
                        {
                            GameObject.Find("Cloud2").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                        }
                        else if (Cloud.bCloud2 == false)
                        {
                            Cloud.bCloud2 = true;
                            Cloud.bCloudAnim = true;
                        }

                        bOnce = false;
                    }

                }
                break;
            case "Stage3":
                if (bClear[2] == true) 
                {
                    if (bOnce == true)
                    {
                        GameObject.Find("Stage4").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                        if (Cloud.bCloud3 == true)
                        {
                            GameObject.Find("Cloud3").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                        }
                        else if (Cloud.bCloud3 == false)
                        {
                            Cloud.bCloud3 = true;
                            Cloud.bCloudAnim = true;
                        }

                        bOnce = false;
                    }

                }
                break;
            case "Stage4":
                if (bClear[3] == true)
                {
                    if (bOnce == true)
                    {
                        GameObject.Find("Stage5").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

                        if (Cloud.bCloud4 == true)
                        {
                            GameObject.Find("Cloud4").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                        }
                        else if (Cloud.bCloud4 == false)
                        {
                            Cloud.bCloud4 = true;
                            Cloud.bCloudAnim = true;
                        }

                        bOnce = false;
                    }

                }
                break;

            case "Stage5":
                if (bClear[4] == true)
                {
                    if (bOnce == true)
                    {

                        if (EndAnim.bClear == false)
                        {
                            EndAnim.bEndAnim = true;
                            EndAnim.bClear = true;
                        }
                        bOnce = false;
                    }

                }
                break;
        }
    }

    private void SetPopUp(string sName)
    {
        switch (sName)
        {
            case "Stage1":
                GameObject.Find("popup").GetComponent<SpriteRenderer>().sprite = Stage1;
                break;

            case "Stage2":
                GameObject.Find("popup").GetComponent<SpriteRenderer>().sprite = Stage2;
                break;

            case "Stage3":
                GameObject.Find("popup").GetComponent<SpriteRenderer>().sprite = Stage3;
                break;

            case "Stage4":
                GameObject.Find("popup").GetComponent<SpriteRenderer>().sprite = Stage4;
                break;

            case "Stage5":
                GameObject.Find("popup").GetComponent<SpriteRenderer>().sprite = Stage5;
                break;
        }
    }
}
