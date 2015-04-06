using UnityEngine;
using System.Collections;

public class CollisionKeyStoneMoveOther : MonoBehaviour {

	StateMachine currentGameState;
	ActiveBubble activeBubble;
	Transform transformOfCurrentGameState, transformOfActiveBubble;
	public bool movePlayerToPosition;
	bool movingBubbleOut;
	GameObject bubble;
	Vector3 storedPlayerPositionBeforeKeyStone = Vector3.zero;
	void Start () {
		this.transformOfCurrentGameState = GameObject.Find ("CurrentGameState").transform;
		this.currentGameState = this.transformOfCurrentGameState.GetComponent<StateMachine> ();
		this.transformOfActiveBubble = GameObject.FindGameObjectWithTag ("CurrentActiveObjects").transform;
		this.activeBubble = this.transformOfActiveBubble.GetComponent<ActiveBubble> ();

	}
	

	void Update () {

		if (this.movePlayerToPosition && this.currentGameState.currentState == CurrentState.KeyStone) {
			if(this.storedPlayerPositionBeforeKeyStone == Vector3.zero)
			{
				this.storedPlayerPositionBeforeKeyStone = this.bubble.transform.position * 2.5f;
				Debug.Log(this.storedPlayerPositionBeforeKeyStone);
			}
			this.bubble.gameObject.transform.position = Vector3.Lerp(this.bubble.transform.position,this.gameObject.transform.position, 0.05f);
		}
		if (this.currentGameState.currentState == CurrentState.KeyStone && !this.movePlayerToPosition && this.storedPlayerPositionBeforeKeyStone != Vector3.zero) 
		{
			this.movingBubbleOut = true;
			this.bubble.gameObject.transform.position = Vector3.Lerp(this.bubble.transform.position,this.storedPlayerPositionBeforeKeyStone, 0.05f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bubble" && !this.movingBubbleOut) 
		{
			this.movePlayerToPosition = true;
			this.bubble = other.gameObject;
			this.currentGameState.currentState = CurrentState.KeyStone;
			this.activeBubble.CurrentActiveKeyStone = this.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D other )
	{
		if (other.tag == "Bubble") 
		{
			Vector3 storedPlayerPositionBeforeKeyStone = Vector3.zero;
			this.currentGameState.currentState = CurrentState.Playing;
			this.movingBubbleOut = false;
		}
	}
}
