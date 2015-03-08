using UnityEngine;
using System.Collections;

public class DeactivateBubble : MonoBehaviour {

    ActiveBubble activeBubble;
    Transform transformActiveBubble;
	void Start () {
        transformActiveBubble = GameObject.FindGameObjectWithTag("CurrentActiveBubble").transform;
        activeBubble = transformActiveBubble.GetComponent<ActiveBubble>();
	}
	
	void Update () {
	    if(activeBubble.CurrentActiveBubble == null)
        {
            gameObject.GetComponent<GUITexture>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<GUITexture>().enabled = true;
            if (gameObject.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
            {
                activeBubble.CurrentActiveBubble = null;
            }
        }
	}
}
