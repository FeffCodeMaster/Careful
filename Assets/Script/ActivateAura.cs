﻿using UnityEngine;
using System.Collections;

public class ActivateAura : MonoBehaviour {

    ActiveBubble activeBubble;
    Transform transformActiveBubble;
    SpriteRenderer spriteRender;
    GameObject parent;
	void Start () {
        transformActiveBubble = GameObject.FindGameObjectWithTag("CurrentActiveObjects").transform;
        this.activeBubble = transformActiveBubble.GetComponent<ActiveBubble>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        parent = gameObject.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.activeBubble.CurrentActiveBubble == parent)
        {
            this.spriteRender.enabled = true;
        }
        else
        {
            this.spriteRender.enabled = false;
        }
	}
}
