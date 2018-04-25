using UnityEngine;

public class FailPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Animator>().SetTrigger("JumpLeft");
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.GetComponent<Animator>().SetTrigger("JumpLeft");
        this.gameObject.transform.position -= new Vector3( 0.1f, 0.0f);
	}
}
