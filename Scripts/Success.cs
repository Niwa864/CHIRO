using UnityEngine;
using UnityEngine.SceneManagement;

public class Success : MonoBehaviour
{
    public static bool bSuccess;
    private bool bOnce;
    private float fAlfa;
    private int nCnt;

    // Use this for initialization
    void Start()
    {
        bSuccess = false;
        bOnce = true;
        fAlfa = 1.0f;
        nCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bSuccess == false) return;

        if (bOnce == true)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            bOnce = false;
        }

        nCnt++;

        if (nCnt < 30) return;

        if (this.GetComponent<SpriteRenderer>().color.a > 0.0f)
            this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, fAlfa);

        if (this.GetComponent<Transform>().localScale.x > 0.0f)
            this.GetComponent<Transform>().localScale -= new Vector3(0.02f, 0.02f);

        if (this.GetComponent<SpriteRenderer>().color.a < 0.2f && Go.bGo == false)
            Go.bGo = true;

        if (fAlfa <= 0.0f)
        {

            SceneManager.LoadScene("Fade", LoadSceneMode.Additive);
            Destroy(this);
        }

        fAlfa = fAlfa - 0.02f;
    }
}

