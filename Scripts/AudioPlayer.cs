using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public AudioClip Audio;
    public static bool bAudio;

	// Use this for initialization
	void Start () {
        bAudio = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (bAudio == true)
        {
            if (this.GetComponent<AudioSource>().clip == Audio) return;

            this.GetComponent<AudioSource>().volume -= 0.5f * Time.deltaTime;

            if (this.GetComponent<AudioSource>().volume <= 0.0f)
            {
                this.GetComponent<AudioSource>().clip = Audio;
                this.GetComponent<AudioSource>().Play();
                this.GetComponent<AudioSource>().volume = 1.0f;
            }

            bAudio = false;
        }
	}
}
