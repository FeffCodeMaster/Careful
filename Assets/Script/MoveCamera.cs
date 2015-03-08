using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    // CLEAN THIS SHIIT UP MAN!!!
    ActiveBubble activeBubble;
    Transform transformActiveBubble;
    Vector2 orginTouchPoint;
    Vector2 mousePosition;
    float repsoneTimeForCameraTouch = 0.01f;

    Rigidbody2D rigidbody;
    bool pressed = false;
    void Start()
    {
        this.transformActiveBubble = GameObject.FindGameObjectWithTag("CurrentActiveBubble").transform;
        this.activeBubble = this.transformActiveBubble.GetComponent<ActiveBubble>();
        this.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        this.orginTouchPoint = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            if (activeBubble.CurrentActiveBubble == null)
            {
                this.pressed = true;
            }

        }

        if (this.pressed)
        {
            this.repsoneTimeForCameraTouch -= Time.deltaTime;
            if (this.repsoneTimeForCameraTouch < 0)
            {
                if (this.orginTouchPoint == Vector2.zero)
                {
                    this.orginTouchPoint = Input.mousePosition;
                    

                }
                this.mousePosition = Input.mousePosition;

                Vector2 diffrentBetweenVectors = this.orginTouchPoint - this.mousePosition;
                var angle = Mathf.Atan2(diffrentBetweenVectors.y, diffrentBetweenVectors.x);
                Vector2 force = new Vector2((float)Mathf.Cos(angle), (float)Mathf.Sin(angle));

                var newPosition = Vector2.zero;
                newPosition.x = 1 * Mathf.Cos(angle * Mathf.PI / 180) * angle;
                newPosition.y = 1 * Mathf.Sin(angle * Mathf.PI / 180) * angle;



                if (!this.mousePosition.Equals(this.orginTouchPoint))
                {
                    
                    

                        gameObject.transform.position += transform.right * force.x / 15;
                        gameObject.transform.position += transform.up * force.y / 15;
                    
                }
            }
        }

        if (activeBubble.CurrentActiveBubble != null)
        {
            this.pressed = false;

        }

        if (Input.GetMouseButtonUp(0))
        {

            this.pressed = false;
            this.orginTouchPoint = Vector2.zero;
            this.rigidbody.velocity = Vector2.zero;
            this.rigidbody.angularVelocity = 0f;
            this.repsoneTimeForCameraTouch = 0.1f;


        }
    }
}
