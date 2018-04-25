using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchRavit : MonoBehaviour {
    
    private GameObject Camera;
    private Camera main;
    private bool bOnce;

	// Use this for initialization
	void Start () {

        Camera = GameObject.Find("Main Camera");
        bOnce = true;   
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<SpriteRenderer>().color.a == 0.0f) return;
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
                SceneManager.LoadScene("Stage");
            }
        }
    }
}
