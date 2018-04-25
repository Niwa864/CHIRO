using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    private GameObject Camera;
    private Camera main;
    private bool bOnce;
    private bool bBack;

	// Use this for initialization
	void Start () {
        Camera = GameObject.Find("Main Camera");
        bOnce = true;   
	}
	
	// Update is called once per frame
    void Update()
    {
        GetMouse();
    }
    private void GetMouse()
    {
        main = Camera.GetComponent<Camera>();
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (col == this.GetComponent<Collider2D>() && bOnce == true)
            {
                Fade.nAlfa = 2;
                SceneManager.LoadScene("Stage");
                bOnce = false;
            }
        }
    }
}