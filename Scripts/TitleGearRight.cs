using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGearRight : MonoBehaviour
{

    private GameObject mainCamera;
    private Camera main;
    private bool bClick;
    private GameObject Right;


    Vector3 vPos;
    Vector3 vTemp;

    // Use this for initialization
    void Start()
    {

        mainCamera = GameObject.Find("Main Camera");
        Right = GameObject.Find("TitleRight");
        bClick = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (TitleGear.bNext == true) return;

        GetMouse();

        Vector3 temp = transform.position;

        if (this.GetComponent<Transform>().transform.position.y > 5.4f)
            this.GetComponent<Transform>().transform.position = new Vector3(temp.x, -5.3f);

        if (this.GetComponent<Transform>().transform.position.y < -5.4f)
            this.GetComponent<Transform>().transform.position = new Vector3(temp.x, 5.3f);

        if (bClick == true)
        {
            if (vPos.x > 0.5f/*&& Input.touchCount == 1*/)
            {
                Right.GetComponent<Transform>().transform.position -= new Vector3(((vPos.x - 0.5f) * 0.1f), 0.0f * 0.05f, 0.0f) * Time.deltaTime;

                GameObject.Find("TitleLeft").GetComponent<Transform>().transform.position += new Vector3(((vPos.x - 0.5f) * 0.1f), 0.0f * 0.05f, 0.0f) * Time.deltaTime;
            }
            else
            {
                Right.GetComponent<Transform>().transform.position -= new Vector3(0.0f, (vPos.y * 0.1f), 0.0f) * Time.deltaTime;
            }
        }

    }

    private void GetMouse()
    {
        main = mainCamera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (bClick == false)
                if (col == this.GetComponent<Collider2D>())
                {
                    vTemp = mousePos;
                    bClick = true;
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
            }
        }
    }
}
