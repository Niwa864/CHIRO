using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailKitune5 : MonoBehaviour {

    public GameObject kitune;
    public static int nUsagi;
    private bool bOnce;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < nUsagi; i++)
        {
            GameObject obj = Instantiate<GameObject>(kitune);
            obj.transform.position = GameObject.Find("kitune").GetComponent<Transform>().transform.position;
            obj.transform.position -= new Vector3(4.0f * i, 0.0f);
            this.gameObject.transform.position -= new Vector3(4.0f, 0.0f);
        }
        bOnce = true;
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position += new Vector3(0.1f, 0.0f);

        if (this.gameObject.transform.position.x > 13.0f)
            if (bOnce == true)
            {
                Success.bSuccess = true;
                Fade.ClrFlg = 2;
                bOnce = false;
            }
	}
}
