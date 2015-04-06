using UnityEngine;
using System.Collections;
public class ActiveBubble : MonoBehaviour {

	//RENAME THIS SCRIPT!!! AND DO IT FAST

    GameObject currentActiveBubble;
	GameObject currentActiveKeyStone;

	void Start () {
	    
	}
	
	
	void Update () {
	
	}
    public GameObject CurrentActiveBubble
    {
        get { return this.currentActiveBubble; }
        set { this.currentActiveBubble = value; }
    }
	public GameObject CurrentActiveKeyStone
	{
		get { return this.currentActiveKeyStone; }
		set { this.currentActiveKeyStone = value;}
	}
}
