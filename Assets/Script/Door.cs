using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool open = false;
    public bool verticalDoor = false;
    public int movementSteps;
    int steppedMoved = 0;
    SpriteRenderer spriteRender;
	void Start () {
        this.spriteRender = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update () {
        
        if (this.open && steppedMoved < movementSteps)
        {
            if (verticalDoor)
            {
                transform.position += transform.up * 0.1f;
            }
            else
            { 
                transform.position += transform.right * 0.1f;
            }
            this.steppedMoved++;
        }
        if (!this.open && steppedMoved > 0)
        {
            if (verticalDoor)
            {
                transform.position -= transform.up * 0.1f;
            }
            else
            {
                transform.position -= transform.right * 0.1f;
            }
            this.steppedMoved--;
        }
	}
}
