using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour
{

    public string doorName;
    public bool key;
    public bool toogleKeyStone;
    Transform transformsOfDoor;
    Door door;
    void Start()
    {
        transformsOfDoor = GameObject.Find(doorName).transform;
        door = transformsOfDoor.GetComponent<Door>();
        if (key)
        {
            toogleKeyStone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log ("hit");
        if (other.tag == "Bubble" || other.name =="KeyStone")
        {
            door.open = true;
            if (key)
            {
                Destroy(gameObject);
            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
		if (other.tag == "Bubble" || other.name =="KeyStone")
        {
            if (toogleKeyStone)
            {
                Debug.Log("hit");
                door.open = false;
            }
        }
    }
}
