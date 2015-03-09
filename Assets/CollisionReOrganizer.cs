using UnityEngine;
using System.Collections;

public class CollisionReOrganizer : MonoBehaviour {

	ReorganizeWalls reorganizeWalls;
	Transform transformOfReoragnizeWalls;
	public string ParentOfWalls;
	void Start () {
		this.transformOfReoragnizeWalls = GameObject.Find (ParentOfWalls).transform;
		this.reorganizeWalls = this.transformOfReoragnizeWalls.GetComponent<ReorganizeWalls> ();
	}
	

	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bubble") 
		{
			this.reorganizeWalls.StartReorganize = true;
		}
	}
}
