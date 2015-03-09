using UnityEngine;
using System.Collections;

public class ReorganizeWalls : MonoBehaviour {

	public bool StartReorganize;
	public int wallInPlaceCount;

	StateMachine currentStateMachine;
	Transform transformOfCurrentStateMachine;

	void Start () {
		this.transformOfCurrentStateMachine = GameObject.Find ("CurrentGameState").transform;
		this.currentStateMachine = this.transformOfCurrentStateMachine.GetComponent<StateMachine>();

	}
	
	// Update is called once per frame
	void Update () {
		if (StartReorganize) 
		{
			this.currentStateMachine.currentState = CurrentState.Reorganize;
		}

		if (wallInPlaceCount == this.transform.childCount-1) 
		{
			this.currentStateMachine.currentState = CurrentState.Playing;
		}
	}
}
