using UnityEngine;
using System.Collections;

public class CollisionDeath : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bubble")
        {
            var applicationName = Application.loadedLevelName;
            Application.LoadLevel(applicationName);
        }
    }

}
