using UnityEngine;
using System.Collections;
public class ActiveBubble : MonoBehaviour {

    GameObject currentActiveBubble;
	void Start () {
	    
	}
	
	
	void Update () {
	
	}
    public GameObject CurrentActiveBubble
    {
        get { return this.currentActiveBubble; }
        set { this.currentActiveBubble = value; }
    }
}
