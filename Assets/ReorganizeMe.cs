using UnityEngine;
using System.Collections;

public class ReorganizeMe : MonoBehaviour {

	public Vector3 position;
	public Vector3 rotation;
	public Vector3 scale;
	
	bool objectDone;

	ReorganizeWalls reorginizeWalls;
	Transform transformOfReorginizeWalls;
	void Start () {
		this.transformOfReorginizeWalls = this.transform.parent.transform;
		this.reorginizeWalls = this.transformOfReorginizeWalls.GetComponent<ReorganizeWalls>();

	}
	
	// Update is called once per frame
	void Update () {
		if (this.reorginizeWalls.StartReorganize ) {
			this.ReorganizePostion ();
			this.ReorganizeRotation();
		}

		Vector3 gPostion = new Vector3 (Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(this.transform.position.y), Mathf.RoundToInt(this.transform.position.z));
		Vector3 gRotation = new Vector3 (Mathf.RoundToInt(this.transform.eulerAngles.x), Mathf.RoundToInt(this.transform.eulerAngles.y), Mathf.RoundToInt(this.transform.eulerAngles.z));



		if(gPostion.Equals(this.position) && gRotation.Equals(this.rotation) && !this.objectDone)
		{
			print("Movement Done of: " + this.gameObject.name); 
			this.reorginizeWalls.wallInPlaceCount++;
			this.objectDone = true;

		}
	
	}

	void ReorganizeRotation ()
	{
		Quaternion newRotation = Quaternion.AngleAxis(rotation.z, Vector3.forward);
		transform.rotation= Quaternion.Slerp(transform.rotation, newRotation, .05f);
	
	}

	void ReorganizePostion ()
	{

		transform.position = Vector3.Lerp(this.transform.position, this.position, 0.1f);
	}
}
