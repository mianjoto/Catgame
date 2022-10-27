using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    [SerializeField] private string _signMessage;

    void Update()
    {
        Interact();
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(GameManager.InteractKey) && CanInteract)
        {
            print(_signMessage);
            // TODO: Add sign message
        }
    }
}
