using UnityEngine;
using System.Collections;

public class ReorganizeWalls : MonoBehaviour {

	public bool StartReorganize;
	public int wallInPlaceCount;

	StateMachine currentStateMachine;
	Transform transformOfCurrentStateMachine;

	bool movementComplete;

	void Start () {
		this.transformOfCurrentStateMachine = GameObject.Find ("CurrentGameState").transform;
		this.currentStateMachine = this.transformOfCurrentStateMachine.GetComponent<StateMachine>();

	}
	
	// Update is called once per frame
	void Update () {
		if (this.StartReorganize) 
		{
			this.currentStateMachine.currentState = CurrentState.Reorganize;
		}

		if (wallInPlaceCount == this.transform.childCount && !this.movementComplete) 
		{

			this.currentStateMachine.currentState = CurrentState.Playing;
			this.StartReorganize = false;
			this.movementComplete = true;
		}
	}
}
