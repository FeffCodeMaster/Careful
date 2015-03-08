using UnityEngine;
using System.Collections;

public class ActivateAura : MonoBehaviour {

    ActiveBubble activeBubble;
    Transform transformActiveBubble;
    SpriteRenderer spriteRender;
    GameObject parent;
	void Start () {
        transformActiveBubble = GameObject.FindGameObjectWithTag("CurrentActiveBubble").transform;
        activeBubble = transformActiveBubble.GetComponent<ActiveBubble>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        parent = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    if(activeBubble.CurrentActiveBubble == parent)
        {
            spriteRender.enabled = true;
        }
        else
        {
            spriteRender.enabled = false;
        }
	}
}
