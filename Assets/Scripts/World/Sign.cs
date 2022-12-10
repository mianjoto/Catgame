using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    [SerializeField] private string _signMessage;

    void OnEnable()
    {
        InputListener.OnInteractKeyDown += Interact;
    }

    void OnDisable()
    {
        InputListener.OnInteractKeyDown -= Interact;
    }

    public override void Interact()
    {
        if (CanInteract)
        {
            print(_signMessage);
            // TODO: Add sign message
        }
    }
}
