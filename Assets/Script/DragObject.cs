using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
    // CLEAN THIS SCRIPT UP!!!

    SpriteRenderer spriteRender;
    Transform transformActiveBubble, transformOfCurrentState;
    ChangePosition changePosition;
    ActiveBubble activeBubble;
    StateMachine currentStateMachine;

    bool drag = false;
    void Start()
    {

        this.transformActiveBubble = GameObject.FindGameObjectWithTag("CurrentActiveBubble").transform;
        this.transformOfCurrentState = GameObject.Find("CurrentGameState").transform;

        this.currentStateMachine = this.transformOfCurrentState.GetComponent<StateMachine>();
        this.activeBubble = this.transformActiveBubble.GetComponent<ActiveBubble>();
        this.spriteRender = this.gameObject.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (this.currentStateMachine.currentState == CurrentState.Playing)
        {
            this.DragMovement();
        }

        if (this.currentStateMachine.currentState == CurrentState.Paus || this.currentStateMachine.currentState == CurrentState.Reorganize)
        {
            this.StopRigidBodyMovement();
        }
    }

    private void StopRigidBodyMovement()
    {
        this.gameObject.transform.parent.GetComponent<Rigidbody2D>().Sleep();
    }

    private void DragMovement()
    {
        var mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var distance = Vector3.Distance(gameObject.transform.parent.position, gameObject.transform.position);
        mousePostion.z = 0;
        Vector2 mPosition = new Vector2((int)mousePostion.x, (int)mousePostion.y);
        Vector2 gameObjectPosition = new Vector2((int)gameObject.transform.position.x, (int)gameObject.transform.position.y);
        if (Input.GetMouseButtonDown(0) && activeBubble.CurrentActiveBubble == null)
        {
            drag = true;
            activeBubble.CurrentActiveBubble = gameObject.transform.parent.gameObject;
        }

        if (drag && activeBubble.CurrentActiveBubble == gameObject.transform.parent.gameObject)
        {
            Vector2 gameObject_position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Vector2 parent = new Vector2(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y);
            Vector2 mP = new Vector2(mousePostion.x, mousePostion.y);
            gameObject.transform.position = mousePostion;
            Vector2 v2 = parent - gameObject_position;
            var angle = Mathf.Atan2(v2.y, v2.x);
            Vector2 one = new Vector2((float)Mathf.Cos(angle), (float)Mathf.Sin(angle));
            gameObject.transform.parent.GetComponent<Rigidbody2D>().AddForce(one / 2);

        }

        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
            gameObject.transform.position = gameObject.transform.parent.position;
            activeBubble.CurrentActiveBubble = null;
        }

        if (activeBubble.CurrentActiveBubble != null && activeBubble.CurrentActiveBubble == gameObject.transform.parent.gameObject)
        {
            spriteRender.color = Color.red;
        }

        if (activeBubble.CurrentActiveBubble == null)
        {
            spriteRender.color = Color.blue;
        }
    }
}
