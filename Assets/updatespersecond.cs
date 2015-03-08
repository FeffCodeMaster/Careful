using UnityEngine;
using System.Collections;

public class updatespersecond : MonoBehaviour {

    GUIText guiText;
	void Start () {
        guiText = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
        var framRate = (1.0f / Time.deltaTime);
        this.guiText.text = framRate.ToString();
        Application.targetFrameRate = 60;
	}
}
