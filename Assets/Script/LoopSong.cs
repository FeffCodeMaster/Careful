using UnityEngine;
using System.Collections;

public class LoopSong : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip song;
    bool first;
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = song;
        if (!this.first)
        { 
            audioSource.Play();
            this.first = true;
        }
      
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
