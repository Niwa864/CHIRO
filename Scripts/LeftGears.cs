using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeftGears : MonoBehaviour 
{
    static bool g_bUpCollition = false;
    static bool g_bDownCollition = false;
    static bool g_bRightCollition = false;
    public static bool bQuadCollision;
    static public int nSpeed = 1;
    private GameObject Left;
    private GameObject Camera;
    private Camera mainC;
    Vector3 vPosL;
    Vector3 vTempL;
    bool bClickMouse;
    public static bool bLeft;

	// Use this for initialization
	void Start (  ) 
    {
        g_bUpCollition = false;
        g_bDownCollition = false;
        g_bRightCollition = false;
        bClickMouse = false;
        bQuadCollision = false;
        bLeft = false;

        Left = GameObject.Find("Left");
        Camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update (  ) 
    {
        if (Pause.bStop == true) return;
        if (Fade.nAlfa != 2) return;
        if (Go.bMove == false) return;
        GetMouse();
        Stay2D();

        /*if (vPosL.y < 0)
            g_bDownCollition = true;
        else if (vPosL.y > 0)
            g_bUpCollition = true;*/

        if (bClickMouse && g_bUpCollition == false && g_bRightCollition == false && g_bDownCollition == false)
        {
            if (vPosL.x < -0.5f && RightGears.bRight == false /*&& Input.touchCount == 1*/)
            {
                if (bQuadCollision == false)
                    Left.GetComponent<Transform>().transform.position -= new Vector3(((vPosL.x - 0.5f) * 0.1f) * (nSpeed + 4), 0.0f, 0.0f) * Time.deltaTime;
                
                if(RightGears.bQuad == false) 
                    GameObject.Find("Right").GetComponent<Transform>().transform.position += new Vector3(((vPosL.x - 0.5f) * 0.1f) * (nSpeed + 4), 0.0f, 0.0f) * Time.deltaTime;
                    
            }
            else
            {

                Left.GetComponent<Transform>().transform.position -= new Vector3(0.0f, (vPosL.y * 0.05f) * (nSpeed + 4), 0.0f) * Time.deltaTime;
            }
        }
        Vector3 temp = transform.position;
        if (transform.position.y > 4.0f)
            transform.position = new Vector3(temp.x, -5.4f, 0.0f);

        if (transform.position.y < -5.5f)
            transform.position = new Vector3(temp.x, 3.9f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "Quad") &&
                    collision.transform.position.y - 0.33f < transform.position.y &&
                    collision.transform.position.y + 0.33f > transform.position.y)
        {
            g_bRightCollition = true;
        }

        if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "Quad") &&
                    transform.position.y - 0.33f > collision.transform.position.y)
        {
            g_bUpCollition = true;
        }


        if ((collision.gameObject.tag == "RightGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "Quad") &&
                    transform.position.y + 0.33f < collision.transform.position.y)
        {
            g_bDownCollition = true;
        }

        if (collision.gameObject.tag == "Quad")
        {
            bQuadCollision = true;
        }
    }

    void Stay2D()
    {

        if (Blocks.bJumpUp == false && Blocks.bJumpDown == false)
        {
            if (g_bRightCollition == true)
                
                { // 当たったものが右ギアより左の場合
                    Left.GetComponent<Transform>().transform.position -= new Vector3(0.01f, 0.0f) * Time.deltaTime;
                }

            if (g_bDownCollition == true)
                {
                    Left.GetComponent<Transform>().transform.position -= new Vector3(0.0f, 0.01f) * Time.deltaTime;
                }

            if (g_bUpCollition == true)
                
                {
                    Left.GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.01f) * Time.deltaTime;
                }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.gameObject.tag == "RightGears" || col.gameObject.tag == "Blocks" || col.gameObject.tag == "Quad"))
        {
            g_bUpCollition = false;
            g_bDownCollition = false;
            g_bRightCollition = false;
        }

        if (col.gameObject.tag == "Quad")
        {
            bQuadCollision = false;
        }
    }


    void GetMouse()
    {
        mainC = Camera.GetComponent<Camera>();
        Vector3 mousePos = mainC.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (bClickMouse == false)
                if (col == this.GetComponent<Collider2D>())
                {
                    vTempL = mousePos;
                    bClickMouse = true;
                    bLeft = true;
                }


        }
        if (bClickMouse == true)
        {
            if (Input.GetMouseButton(0))
            {
                vPosL = new Vector3(vTempL.x - mousePos.x, vTempL.y - mousePos.y);
            }

            if (Input.GetMouseButtonUp(0))
            {
                bClickMouse = false;
                bLeft = false;

            }
        }

    }
 }
