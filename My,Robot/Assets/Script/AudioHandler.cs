using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour {

    public AudioClip newAudio;

    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!source.isPlaying)
        {
            source.clip = newAudio;
            source.Play();
        }
	}
}
