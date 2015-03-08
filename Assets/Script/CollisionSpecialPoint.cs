using UnityEngine;
using System.Collections;

public class CollisionSpecialPoint : MonoBehaviour {

	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bubble")
        {
            Destroy(gameObject);
        }
    }

}
