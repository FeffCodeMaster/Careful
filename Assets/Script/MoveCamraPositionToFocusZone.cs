using UnityEngine;
using System.Collections;

public class MoveCamraPositionToFocusZone : MonoBehaviour {

    string currentZone;
    Vector3 currentCameraZonePosition;
    
	void Start () {
	
	}
	
	void Update () {

        CameraMovement();   
	}
    public void CameraMovement()
    {
        Vector3 cameraposition = gameObject.transform.position;
        if (currentCameraZonePosition.x < cameraposition.x)
        {
            cameraposition -= transform.right * 0.1f;
        }
        if (currentCameraZonePosition.x > cameraposition.x)
        {
            cameraposition += transform.right * 0.1f;
        }
        if (currentCameraZonePosition.y < cameraposition.y)
        {
            cameraposition -= transform.up * 0.1f;
        }
        if (currentCameraZonePosition.y > cameraposition.y)
        {
            cameraposition += transform.up * 0.1f;
        }
        gameObject.transform.position = cameraposition;
    }
    public string CurrentZone
    {
        get { return this.currentZone; }
        set { this.currentZone = value; }
    }
    public Vector3 CurrentCameraZonePosition
    {
        get { return this.currentCameraZonePosition; }
        set { this.currentCameraZonePosition = value; }
    }
}
