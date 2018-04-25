using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnim : MonoBehaviour {

    public static bool bEndAnim = false;
    public static bool bClear = false;
    static bool bOnce = true;
    private bool bPopup;

	// Use this for initialization
	void Start () {
        bPopup = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (bClear == true && bOnce == false)
        {
            GameObject.Find("Ravit").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            GameObject.Find("Ravit").GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f);
            GameObject.Find("Ravit").GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
        }
        if (bEndAnim == false) return;
        if (Fade.nAlfa != 2) return;

        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        this.transform.position += new Vector3( 1.0f, 0.0f) * Time.deltaTime;

        if (this.transform.position.x > 10.0f)
        {
            bPopup = true;
        }

        if (bPopup == true)
            if (GameObject.Find("Ravit").GetComponent<Transform>().localScale.y < 0.3f)
            {
                GameObject.Find("Ravit").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                GameObject.Find("Ravit").GetComponent<Transform>().localScale += new Vector3(0.0f, 0.02f);
                GameObject.Find("Ravit").GetComponent<BoxCollider2D>().size += new Vector2(0.1f, 0.1f);
                GameObject.Find("Ravit").GetComponent<Transform>().transform.position += new Vector3(0.0f, 0.05f);
            }
            else
            {
                bEndAnim = false;
                bOnce = false;
            }
	}
}