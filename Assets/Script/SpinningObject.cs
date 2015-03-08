using UnityEngine;
using System.Collections;

public class SpinningObject : MonoBehaviour {

    public float speedRight;
    public float speedUp;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector2.right * this.speedRight);
        this.transform.Rotate(Vector2.up * this.speedUp);
	}
}
