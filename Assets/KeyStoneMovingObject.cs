using UnityEngine;
using System.Collections;

public class KeyStoneMovingObject : MonoBehaviour {

	StateMachine currentGameState;
	Transform transformOfCurrentGameState;
	Vector3 touchStartPosition,currentTouchPosition;
	Vector3 startPosition;
	public bool resetPosition;
	void Start () {
		this.transformOfCurrentGameState = GameObject.Find ("CurrentGameState").transform;
		this.currentGameState = this.transformOfCurrentGameState.GetComponent<StateMachine> ();
		this.startPosition = this.gameObject.transform.position;
	}
	

	void Update () {
		if (this.currentGameState.currentState == CurrentState.KeyStone) 
		{
			if(Input.GetMouseButtonDown(0))
			{
				this.touchStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				this.currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
			if(Input.GetMouseButton(0))
			{
				this.currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if(!this.touchStartPosition.Equals(this.currentTouchPosition))
				{
					Vector2 v2 = this.touchStartPosition - this.currentTouchPosition;
					var angle = Mathf.Atan2(v2.y, v2.x);
					Vector2 one = new Vector2((float)Mathf.Cos(angle), (float)Mathf.Sin(angle));
					this.transform.position -= transform.right * one.x/80;
					this.transform.position -= transform.up * one.y/80;
				}
			}

				
		}
		if (resetPosition) {
			this.transform.position = this.startPosition;
			resetPosition = false;
		}
	}
}
