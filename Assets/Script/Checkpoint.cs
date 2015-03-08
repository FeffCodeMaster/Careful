using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    string levelName;
    LevelCompleteBackGround levelCompleteBackGround;
    StateMachine currentStateMachine;
    Transform transformOfLevelCompleteBackGround,transformOfCurrentStateMachine;
	void Start () {
        this.levelName = Application.loadedLevelName;
        transformOfLevelCompleteBackGround = GameObject.Find("CompleteBackground").transform;
        levelCompleteBackGround = transformOfLevelCompleteBackGround.GetComponent<LevelCompleteBackGround>();
        this.transformOfCurrentStateMachine = GameObject.Find("CurrentGameState").transform;
        this.currentStateMachine = this.transformOfCurrentStateMachine.GetComponent<StateMachine>();
	}
	
	
	void Update () {
	
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bubble") 
        {
            if (this.levelCompleteBackGround.parent == true)
            {
                this.levelCompleteBackGround.activateMeny = true;
                this.currentStateMachine.currentState = CurrentState.Paus;
                Destroy(this.gameObject);
            }
        }
    }
}
