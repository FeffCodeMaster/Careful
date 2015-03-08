using UnityEngine;
using System.Collections;

public class ZoneSender : MonoBehaviour {

    public Vector3 cameraZonePostion;
    Transform transformOfMainCamera;
    MoveCamraPositionToFocusZone moveCameraPositionToFocusZone;
	void Start () {
        this.transformOfMainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        this.moveCameraPositionToFocusZone = this.transformOfMainCamera.GetComponent<MoveCamraPositionToFocusZone>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bubble")
        {
            //Debug.Log("Current Zone" + gameObject.name);
            this.moveCameraPositionToFocusZone.CurrentZone = gameObject.name;
            this.moveCameraPositionToFocusZone.CurrentCameraZonePosition= this.cameraZonePostion;
        }
    }
}
