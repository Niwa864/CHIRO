using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour {

    
    private GameObject mainCamera;
    private Camera main;
    private bool bOnce;

	// Use this for initialization
	void Start () {

        mainCamera = GameObject.Find("Touch Camera");
        bOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
        GetMouse();
	}

    private void GetMouse()
    {
        main = mainCamera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (bOnce == false) return;
            if (col == this.GetComponent<Collider2D>())
            {
                Fade.Stage = "Title";
                Fade.bGoTitle = true;

                SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
                bOnce = false;
            }
        }
     }
}
