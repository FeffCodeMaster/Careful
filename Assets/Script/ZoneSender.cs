using UnityEngine;
using System.Collections;

public class ZoneSender : MonoBehaviour {

    public Vector3 cameraZonePostion;
	Transform transformOfMainCamera, transformOfCurrentGameState;
    MoveCamraPositionToFocusZone moveCameraPositionToFocusZone;
	StateMachine currentGameState;
	void Start () {
        this.transformOfMainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		this.transformOfCurrentGameState = GameObject.Find ("CurrentGameState").transform;
        
		this.moveCameraPositionToFocusZone = this.transformOfMainCamera.GetComponent<MoveCamraPositionToFocusZone>();
		this.currentGameState = this.transformOfCurrentGameState.GetComponent<StateMachine> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bubble" && this.currentGameState.currentState == CurrentState.Playing)
        {
            this.moveCameraPositionToFocusZone.CurrentZone = gameObject.name;
            this.moveCameraPositionToFocusZone.CurrentCameraZonePosition= this.cameraZonePostion;
        }
	 }
}
