using UnityEngine;

public class Go : MonoBehaviour {

    public static bool bGo;
    public static bool bMove;
    private bool bOnce;
    private float fAlfa;
    private int nCnt;

	// Use this for initialization
	void Start () {
        bMove = false;
        bGo = false;
        bOnce = true;
        fAlfa = 1.0f;
        nCnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (bGo == false) return;

        if (bOnce == true)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            bOnce = false;
        }
        nCnt++;

        if (nCnt < 30) return;

        this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, fAlfa);

        //if (this.GetComponent<Transform>().localScale.x > 0.0f)
        if(fAlfa > 0.0f)
            this.GetComponent<Transform>().localScale += new Vector3(0.05f, 0.05f);
        if (fAlfa <= 0.0f)
        {
            bMove = true;
            Destroy(this);
        }

        fAlfa = fAlfa - 0.05f;
	}
}
