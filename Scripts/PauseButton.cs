using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseButton : MonoBehaviour {

    private GameObject mainCamera;
    private Camera main;
    public Sprite Number1;
    public Sprite Number2;
    public Sprite Number3;
    public Sprite Number4;
    public Sprite Number5;
    public Sprite Number6;
    public Sprite Number7;
    public Sprite Number8;
    public Sprite Number9;

    static private Sprite Number;
    static private int nSpeed = 5;

    private int nFrameCnt = 0;
    private bool bContinueTouch = false;
    private bool bSelectTouch = false;
    private bool bReStartTouch = false;

    static public string sMainNum;

    private string sButton;

    // Use this for initialization
    void Start()
    {
        if (Number == null)
            Number = Number5;

        if(this.gameObject.name != "Restart")
            GameObject.Find("Speed").GetComponent<SpriteRenderer>().sprite = Number;
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade.nAlfa != 2) return;
        GetMouse();
    }

    void GetMouse()
    {
        main = mainCamera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);

        // 効果音再生後の待機と遷移処理
        // もどる
        if (bContinueTouch && nFrameCnt < 30) 
        {
            //Debug.Log(nFrameCnt.ToString());
            nFrameCnt++;
        }
        else if (nFrameCnt >= 30)
        {
            SceneManager.UnloadSceneAsync("Pause");
            Pause.bStop = false;
        }

        // あきらめる
        if (bSelectTouch && nFrameCnt < 30) 
        {
            nFrameCnt++;
        }
        else if (nFrameCnt >= 30)
        {
            SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
            Fade.ClrFlg = 3;
            Fade.Stage = sMainNum;
            Fade.bReturn = true;
            SceneManager.UnloadSceneAsync("Pause");
            Blocks.nCount = 0;
        }

        // もういっかい
        if (bReStartTouch && nFrameCnt < 30) 
        {
            nFrameCnt++;
        }
        else if (nFrameCnt >= 30)
        {
            if (Pause.bStop == true) return;
            if (Blocks.bClear == true)return;
            Fade.Stage = SceneManager.GetActiveScene().name;
            Fade.bOneMore = true;
            SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
            Blocks.nCount = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (col == this.GetComponent<Collider2D>())
            {
                sButton = this.gameObject.name;
                switch(sButton)
                {
                case "Continue":
                    GetComponent<AudioSource>().Play();
                    bContinueTouch = true;
                    //SceneManager.UnloadSceneAsync("Pause");
                    //Pause.bStop = false;
                    break;

                case "Select":
                    GetComponent<AudioSource>().Play();
                    bSelectTouch = true;

                    //SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
                    //Fade.ClrFlg = 3;
                    //Fade.Stage = sMainNum;
                    //Fade.bReturn = true;
                    //SceneManager.UnloadSceneAsync("Pause");
                    //Blocks.nCount = 0;
                    break;

                case "Restart":
                    GetComponent<AudioSource>().Play();
                    bReStartTouch = true;
                    //if (Pause.bStop == true) return;
                    //if (Blocks.bClear == true)return;
                    //Fade.Stage = SceneManager.GetActiveScene().name;
                    //Fade.bOneMore = true;
                    //SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
                    //Blocks.nCount = 0;
                    break;

                case "Right":
                    if (nSpeed < 9)
                    {
                        GetComponent<AudioSource>().Play();
                        nSpeed++;
                        LeftGears.nSpeed = nSpeed;
                        Number = SetSprite(nSpeed);
                        GameObject.Find("Speed").GetComponent<SpriteRenderer>().sprite = Number;
                        
                    }
                    break;

                case "Left":
                    if (nSpeed > 0)
                    {
                        GetComponent<AudioSource>().Play();
                        nSpeed--;
                        LeftGears.nSpeed = nSpeed;
                        Number = SetSprite(nSpeed);
                        GameObject.Find("Speed").GetComponent<SpriteRenderer>().sprite = Number;
                    }
                    break;
                }
            }


        }


    }

    private void GetStage()
    {
        switch (sMainNum)
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

    private Sprite SetSprite(int nCnt)
    {
        switch (nCnt)
        {
            case 1:
                return Number1;
            case 2:
                return Number2;
            case 3:
                return Number3;
            case 4:
                return Number4;
            case 5:
                return Number5;
            case 6:
                return Number6;
            case 7:
                return Number7;
            case 8:
                return Number8;
            case 9:
                return Number9;
        }
        return Number1;
    }
}