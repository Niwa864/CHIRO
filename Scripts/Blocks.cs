using UnityEngine;
using UnityEngine.SceneManagement;

public class Blocks : MonoBehaviour 
{
    bool bBlockMoveRight = false;
    bool bBlockMoveLeft = false;
    bool bBlockMoveUp = false;
    bool bBlockMoveDown = false;
    static public bool bJumpUp;
    static public bool bJumpDown;
    static public bool bClear;
    static public int nNum;
    bool bJumpU;
    bool bJumpD;
    bool bQuadCollition;
    bool bCollsion;

    public static int nCount;
    public static string sReturn;
    public float distance;
    public Sprite tex;
    private int nRandom;
    private int nJump;
    static int nStay;
    static bool bOnce;
    static bool bClearK;
    GameObject Quad;
    float fDelta;
    int nCnt;
    int nOn;

	// Use this for initialization
	void Start (  ) 
    {
        bBlockMoveRight = false;
        bBlockMoveLeft = false;
        bBlockMoveUp = false;
        bBlockMoveDown = false;
        bQuadCollition = false;
        bJumpUp = false;
        bJumpDown = false;
        bJumpU = false;
        bJumpD = false;
        bOnce = true;
        bCollsion = false;
        bClear = false;
        bClearK = false;

        nStay = 0;
        nCnt = 0;
        nOn = 0;
        nNum = 0;

        nCount++;

        fDelta = 0.0f;
	}
	
	// Update is called once per frame
	void Update (  ) 
    {
        if(nStay == nCount && bOnce == true && nCount != 0)
        {
            Fade.Stage = sReturn;
            Fade.bReturn = true;
            GetStage();
            bClear = true;
            nCnt++;

            if (nCnt == 60)
            {
                GameObject.Find("Gate").GetComponent<SpriteRenderer>().sprite = tex;
                GameObject.Find("Gate").GetComponent<SpriteRenderer>().sortingLayerName = "TimeBG";
                GameObject.Find("Gate").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.9f);

                if (this.gameObject.name == "kitune")
                {
                    GetComponent<Animator>().SetTrigger("Awake");
                    bClearK = true;
                }
            }

            if (nCnt == 120)
            {
                SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
                nCount = 0;
                bOnce = false;
            }
        }

        nNum = nCount - nStay;

        if (bBlockMoveRight == true && bQuadCollition == false)
        {
            //transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime;
            //bBlockMoveRight = false;
            this.GetComponent<Animator>().SetTrigger("JumpRight");
        }
        if (bBlockMoveLeft == true && bQuadCollition == false)
        {
            //transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime;
            //bBlockMoveLeft = false;
            this.GetComponent<Animator>().SetTrigger("JumpLeft");
        }


        if (bBlockMoveDown == true && bQuadCollition == false)
        {
            //bBlockMoveDown = false;
            this.GetComponent<Animator>().SetTrigger("JumpForword");

        }

        if (bBlockMoveUp == true && bQuadCollition == false)
        {
            //bBlockMoveUp = false;
            this.GetComponent<Animator>().SetTrigger("JumpBack");
        }

        nRandom = Random.Range(1, 15);


        if (nRandom <= 1)
        {
            if (bQuadCollition == true || (bBlockMoveUp == false && bBlockMoveLeft == false && bBlockMoveDown == false && bBlockMoveRight == false))
            {
                if (bClearK == true) return;
                this.GetComponent<Animator>().SetTrigger("Stop");
            }
        }

        if (bQuadCollition == true)
        {
            if (fDelta <= 10.0f)
                fDelta += Time.deltaTime;

            Leap(transform.position.x, transform.position.y, Quad.GetComponent<Transform>().transform.position.x,
                Quad.GetComponent<Transform>().transform.position.y, 10.0f, fDelta);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (bQuadCollition) return;
        if (bCollsion == false && collision.gameObject.tag == "Quad")
        {
            bCollsion = true;
            nStay++;
        }

        if ((collision.gameObject.tag == "Quad"))
        {
            bQuadCollition = true;
            Quad = collision.gameObject;
        }

        if (collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears")
            nOn++;

        if (bJumpU == false && bJumpD == false)
        {
            if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "LeftGears") &&
                collision.transform.position.x < transform.position.x &&
                collision.transform.position.y + 0.33f > transform.position.y - 0.33f&&
                collision.transform.position.y - 0.33f < transform.position.y + 0.33f)
            { // 当たったものが右ギアより左の場合
                bBlockMoveRight = true;
                transform.position += new Vector3(10.0f, 0.0f, 0.0f) * Time.deltaTime;
                return;
            }

            if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "LeftGears") &&
                collision.transform.position.x  > transform.position.x &&
                collision.transform.position.y + 0.33f > transform.position.y - 0.33f&&
                collision.transform.position.y - 0.33f < transform.position.y + 0.33f)
            { // 当たったものが右ギアより左の場合
                bBlockMoveLeft = true;
                transform.position -= new Vector3(10.0f, 0.0f, 0.0f) * Time.deltaTime;
                return;
            }

            if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears" || collision.gameObject.tag == "Blocks") &&
                transform.position.y < collision.transform.position.y)
            {
                bBlockMoveDown = true;
                transform.position -= new Vector3(0.0f, 10.0f, 0.0f) * Time.deltaTime;
            }

            if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears" || collision.gameObject.tag == "Blocks") &&
                transform.position.y > collision.transform.position.y )
            {
                bBlockMoveUp = true;
                transform.position += new Vector3(0.0f, 10.0f, 0.0f) * Time.deltaTime;
            }

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (bQuadCollition) return;
        if (collision.gameObject.tag == "Top")
        {
            //transform.position -= new Vector3(0.0f, 2.0f, 0.0f) * Time.deltaTime;
            bJumpD = bJumpDown = true;
        }

        if (collision.gameObject.tag == "Down")
        {
            //transform.position += new Vector3(0.0f, 20.0f, 0.0f) * Time.deltaTime;
            bJumpU = bJumpUp = true;
        }

        if (bJumpD == true && (collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears"))
        {
            transform.position -= new Vector3(0.0f, 0.1f);
        }
        if (bJumpU == true && (collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears"))
        {
            transform.position += new Vector3(0.0f, 0.1f);
        }

        if (bJumpU == false && bJumpD == false)
        {
            if (bBlockMoveLeft == true)
            { // 当たったものが右ギアより左の場合
                transform.position -= new Vector3(0.01f, 0.0f);
            }

            if (bBlockMoveRight == true)
            { // 当たったものが右ギアより左の場合
                transform.position += new Vector3(0.01f, 0.0f);
            }

            if (bBlockMoveUp == true)
            {
                transform.position -= new Vector3(0.0f, 0.01f);
            }

            if (bBlockMoveDown == true)
            {
                transform.position += new Vector3(0.0f, 0.01f);
            }
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears")
        {
            bBlockMoveLeft = bBlockMoveRight = bBlockMoveUp = bBlockMoveDown = false;
            nOn--;
        }

        if (bQuadCollition) return;
        if ((bJumpU == true ||bJumpD == true)&&(collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "LeftGears"))
        {
            if (nOn == 0)
            {
                bJumpU = bJumpUp = false;
                bJumpD = bJumpDown = false;
            }
        }
    }

    void Leap(float fStartX, float fStartY, float fEndX, float fEndY, float fMax, float fCurrent)
    {

        float foutX = fStartX + (fEndX - fStartX) * ((fCurrent - 0.0f) / (fMax - 0.0f));
        float foutY = fStartY + (fEndY - fStartY) * ((fCurrent - 0.0f) / (fMax - 0.0f));

        transform.position = new Vector3(foutX, foutY);

        if (fStartX == fEndX && fStartY == fEndY)
        {
            fDelta = 0.0f;
        }
    }

    private void GetStage()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Main1":
                StageTouch.bClear[0] = true;
                break;
            case "Main2":
                StageTouch.bClear[1] = true;
                break;
            case "Main3":
                StageTouch.bClear[2] = true;
                break;
            case "Main4":
                StageTouch.bClear[3] = true;
                break;
            case "Main5":
                StageTouch.bClear[4] = true;
                break;
        }
    }
 }
