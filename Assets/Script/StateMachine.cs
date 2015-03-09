using UnityEngine;
using System.Collections;

public enum CurrentState
{
    Playing,
    Paus,
	Reorganize
}

public class StateMachine : MonoBehaviour {

    public CurrentState currentState;
	
	void Start () {
        this.currentState = CurrentState.Playing;
	}
	
	
	void Update () {
	    // test 

        if(Input.GetButton("Cancel"))
        {
            this.currentState = CurrentState.Paus;
        }

        if (Input.GetButton("Submit"))
        {
            this.currentState = CurrentState.Playing;
        }
        
	}
}
