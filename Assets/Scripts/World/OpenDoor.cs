using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool _nearDoor;

    void Start()
    {
        _nearDoor = false;
    }

    void Update()
    {
        if (_nearDoor && Input.GetKeyDown(GameManager.InteractKey))
        {
            print("Entered scene in " + this.gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _nearDoor = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _nearDoor = false;
    }
}
