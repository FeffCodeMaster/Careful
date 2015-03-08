using UnityEngine;
using System.Collections;

public enum CameraState
{
    noTarget,
    Target
}
public class ChangePosition : MonoBehaviour {

    Transform obj_bubble;
    Transform objectToFollow;

    public CameraState currentCameraState = CameraState.noTarget;
    
	void Start () {
        this.obj_bubble = GameObject.FindGameObjectWithTag("Bubble").transform;
        this.currentCameraState = CameraState.noTarget;
	}
	
	
	void Update () {
        var mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePostion.z = 0;
        Vector2 mPosition = new Vector2((int)mousePostion.x, (int)mousePostion.y);
        Vector2 gameObjectPosition = new Vector2((int)obj_bubble.transform.position.x, (int)obj_bubble.transform.position.y);
        if (mPosition.Equals(gameObjectPosition) && Input.GetMouseButtonDown(0))
        {
            this.currentCameraState = CameraState.Target;
            ObjectToFollow = obj_bubble;

        }
        followObject();
	}

    public void followObject()
    {
        if(this.currentCameraState == CameraState.Target)
        {
            //gameObject.transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, gameObject.transform.position.z);
            
        }
    }
    private Transform ObjectToFollow
    {
        get { return objectToFollow; }
        set { objectToFollow = value; }  
    }
}
