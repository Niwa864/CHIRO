using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 temp = transform.position;

        if (this.GetComponent<Transform>().transform.position.y > 5.4f)
            this.GetComponent<Transform>().transform.position = new Vector3(temp.x, -5.39f);

        if (this.GetComponent<Transform>().transform.position.y < -5.4f)
            this.GetComponent<Transform>().transform.position = new Vector3(temp.x, 5.39f);  
	}
}
