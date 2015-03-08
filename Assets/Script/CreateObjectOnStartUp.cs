using UnityEngine;
using System.Collections;

public class CreateObjectOnStartUp : MonoBehaviour {

    public GameObject audioSource,curretnGameState;
	void Start () {

        if (GameObject.FindGameObjectWithTag("AudioSource") == null)      
        {  
            var audioSource = GameObject.Instantiate(this.audioSource);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
