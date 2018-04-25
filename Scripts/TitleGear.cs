using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGear : MonoBehaviour {
   
    private GameObject mainCamera;
    private Camera main;
    private bool bClick;
    private GameObject Left;
    static public bool bNext;
    static private bool bOnce;
    static private int nCnt;
    
    
    Vector3 vPos;
    Vector3 vTemp;

	// Use this for initialization
	void Start () {

        mainCamera = GameObject.Find("Main Camera");
        Left = GameObject.Find("TitleLeft");
        bClick = false;
        bNext = false;
        bOnce = true;
        nCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (bNext == true)
        {
            nCnt++;

            if(nCnt == 20 * 13)
                Destroy(GameObject.Find("Destroy"));
            if (nCnt < 30 * 13) return;

            GetScene();
            return;
        }
        GetMouse();

        Vector3 temp = transform.position;

        if (this.GetComponent<Transform>().transform.position.y > 5.4f)
            this.GetComponent<Transform>().transform.position = new Vector3(temp.x, -5.3f);

        if (this.GetComponent<Transform>().transform.position.y < -5.4f)
            this.GetComponent<Transform>().transform.position = new Vector3(temp.x, 5.3f);

        if (bClick == true)
        {
            if (vPos.x < -0.5f/*&& Input.touchCount == 1*/)
            {
                Left.GetComponent<Transform>().transform.position -= new Vector3(((vPos.x - 0.5f) * 0.1f), 0.0f * 0.05f, 0.0f) * Time.deltaTime;

                GameObject.Find("TitleRight").GetComponent<Transform>().transform.position += new Vector3(((vPos.x - 0.5f) * 0.1f), 0.0f * 0.05f, 0.0f) * Time.deltaTime;
            }
            else
            {
                Left.GetComponent<Transform>().transform.position -= new Vector3(0.0f, (vPos.y * 0.1f), 0.0f) * Time.deltaTime;
            }
        }

	}

    private void GetScene()
    {
        Left.GetComponent<Transform>().transform.position -= new Vector3( 1.0f, 0.0f) * Time.deltaTime;
        GameObject.Find("TitleRight").GetComponent<Transform>().transform.position += new Vector3(1.0f, 0.0f) * Time.deltaTime;

        if (Left.GetComponent<Transform>().transform.position.x < (-100 / 15) * 5)
            SceneManager.UnloadSceneAsync("Title");

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
                    Debug.Log("a");
                }


        }
        if (bClick == true)
        {
            if (Input.GetMouseButton(0))
            {
                vPos = new Vector3(vTemp.x - mousePos.x, vTemp.y - mousePos.y);
                Debug.Log(vPos.ToString());
            }

            if (Input.GetMouseButtonUp(0))
            {
                bClick = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RightGears")
            bNext = true;

        if (bOnce == true)
        {
            SceneManager.LoadScene("Stage", LoadSceneMode.Additive);
            Fade.nAlfa = 2;
            bOnce = false;
        }
    }
}
