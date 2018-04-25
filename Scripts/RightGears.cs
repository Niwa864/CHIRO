using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGears : MonoBehaviour
{

    static bool g_bUp = false;
    static bool g_bDown = false;
    static bool g_bLeft = false;
    public static bool bQuad;
    public static bool bRight;
    private GameObject Right;
    private GameObject mainCamera;
    private Camera main;
    Vector3 vPos;
    Vector3 vTemp;
    bool bClick;

    // Use this for initialization
    void Start()
    {
        g_bUp = false;
        g_bDown = false;
        g_bLeft = false;
        bClick = false;
        bQuad = false;
        bRight = false;
        Right = GameObject.Find("Right");
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.bStop == true) return;
        if (Fade.nAlfa != 2) return;
        if (Go.bMove == false) return;

        GetMouse();
        Stay2D();

        if (bClick && g_bLeft == false && g_bUp == false && g_bDown == false)
        {
            if (vPos.x > 0.5f && LeftGears.bLeft == false /*&& Input.touchCount == 1*/)
            {

                if (bQuad == false)
                    Right.GetComponent<Transform>().transform.position -= new Vector3(((vPos.x - 0.5f) * 0.1f) * (LeftGears.nSpeed + 4), 0.0f * 0.05f, 0.0f) * Time.deltaTime;
                
                if(LeftGears.bQuadCollision == false)

                    GameObject.Find("Left").GetComponent<Transform>().transform.position += new Vector3(((vPos.x - 0.5f) * 0.1f) * (LeftGears.nSpeed + 4), 0.0f * 0.05f, 0.0f) * Time.deltaTime;
            }
            else
            {
                Right.GetComponent<Transform>().transform.position -= new Vector3(0.0f, (vPos.y * 0.1f) * (LeftGears.nSpeed + 4), 0.0f) * Time.deltaTime;
            }
        }


        Vector3 temp = transform.position;
        if (transform.position.y > 4.0f)
            transform.position = new Vector3(temp.x, -5.5f, 0.0f);

        if (transform.position.y < -5.5f)
            transform.position = new Vector3(temp.x, 3.8f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "LeftGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "Quad") &&
                    collision.transform.position.y - 0.33f < transform.position.y &&
                    collision.transform.position.y + 0.33f > transform.position.y)
        {
            g_bLeft = true;
        }


        if ((collision.gameObject.tag == "LeftGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "Quad") &&
            transform.position.y - 0.8f > collision.transform.position.y)
        {
            g_bUp = true;
        }


        if ((collision.gameObject.tag == "LeftGears" || collision.gameObject.tag == "Blocks" || collision.gameObject.tag == "Quad") &&
            transform.position.y + 0.8f < collision.transform.position.y)
        {
            g_bDown = true;
        }

        if (collision.gameObject.tag == "Quad")
        {
            bQuad = true;
        }
    }

    void Stay2D()
    {
        if (Blocks.bJumpUp == false && Blocks.bJumpDown == false)
        {
            if (g_bLeft == true)
                
                {
                    Right.GetComponent<Transform>().transform.position += new Vector3(0.01f, 0.0f) * Time.deltaTime;
                }

            if (g_bUp == true)
                {
                    Right.GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.01f) * Time.deltaTime;
                }

            if (g_bDown == true)
                {
                    Right.GetComponent<Transform>().transform.position -= new Vector3(0.0f, 0.01f) * Time.deltaTime;
                }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.gameObject.tag == "LeftGears" || col.gameObject.tag == "Blocks" || col.gameObject.tag == "Quad"))
        {
            g_bUp = false;
            g_bDown = false;
            g_bLeft = false;
        }

        if (col.gameObject.tag == "Quad")
        {
            bQuad = false;
        }
    }

    void GetMouse()
    {
        main = mainCamera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if(bClick == false)
                if (col == this.GetComponent<Collider2D>())
                {   
                    vTemp = mousePos;
                    bClick = true;
                    bRight = true;
                }

            
        }
        if (bClick == true)
        {
            if (Input.GetMouseButton(0))
            {
                vPos = new Vector3(vTemp.x - mousePos.x, vTemp.y - mousePos.y);
            }

            if (Input.GetMouseButtonUp(0))
            {
                bClick = false;
                bRight = false;
            }
        }

        
    }
}