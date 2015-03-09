using UnityEngine;
using System.Collections;

public class CollisionDeath : MonoBehaviour
{

	StateMachine currentStateMachine;
	Transform transformOfCurrentStateMachine;
    void Start()
    {
		this.transformOfCurrentStateMachine = GameObject.Find ("CurrentGameState").transform;
		this.currentStateMachine = this.transformOfCurrentStateMachine.GetComponent<StateMachine> ();
    }


    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bubble" && this.currentStateMachine.currentState != CurrentState.Reorganize)
        {
            var applicationName = Application.loadedLevelName;
            Application.LoadLevel(applicationName);
        }
    }

}
