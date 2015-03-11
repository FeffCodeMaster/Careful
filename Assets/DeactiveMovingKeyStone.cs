using UnityEngine;
using System.Collections;

public class DeactiveMovingKeyStone : MonoBehaviour {

	CollisionKeyStoneMoveOther collisionKeyStoneMoveOther;
	ActiveBubble activeBubble;
	StateMachine currentStateMachine;
	Transform transformOfCurrenStateMachine, transformActiveBubble, transformCollisionKeystoneMoveOther;
	SpriteRenderer spriteRender;
	void Start () {
		this.transformOfCurrenStateMachine = GameObject.Find ("CurrentGameState").transform;
		this.transformActiveBubble = GameObject.FindGameObjectWithTag ("CurrentActiveObjects").transform;
		this.activeBubble = this.transformActiveBubble.GetComponent<ActiveBubble> ();
		this.currentStateMachine = this.transformOfCurrenStateMachine.GetComponent<StateMachine> ();

		this.spriteRender = this.gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.activeBubble.CurrentActiveKeyStone != null) 
		{
			this.transformCollisionKeystoneMoveOther = GameObject.Find (this.activeBubble.CurrentActiveKeyStone.name).transform;
			this.collisionKeyStoneMoveOther = this.transformCollisionKeystoneMoveOther.GetComponent<CollisionKeyStoneMoveOther> ();
		}
		if (this.currentStateMachine.currentState == CurrentState.KeyStone) {

			if (!this.spriteRender.enabled) {
				this.spriteRender.enabled = true;
			}

			this.ButtonPress ();
		}

		else 
		{
			this.spriteRender.enabled = false;
		}
	}

	void ButtonPress ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

			if (hitCollider.transform.name == "DeActiveKeyStone")
			{
				this.collisionKeyStoneMoveOther.movePlayerToPosition = false;

			}
		}
	}
}
