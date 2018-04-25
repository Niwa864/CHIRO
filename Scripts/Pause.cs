using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {

    private GameObject mainCamera;
    private Camera main;

    static public bool bStop;

	// Use this for initialization
	void Start () {

        mainCamera = GameObject.Find("Main Camera");
        bStop = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Fade.bReturn == true) return;
        if (Go.bMove == false) return;

        GetMouse();
	}

    void GetMouse()
    {
        main = mainCamera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (col == this.GetComponent<Collider2D>())
            {
                if (bStop == false)
                {
                    PauseButton.sMainNum = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
                    bStop = true;
                }
            }

            
        }
    }
}
