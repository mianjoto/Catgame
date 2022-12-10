using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    [Header("Scene that the player should switch to upon trigger")]
    private SceneLoader.Scenes _indoorTargetScene;

    void Update()
    {
        Interact();
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(GameManager.InteractKey) && CanInteract)
        {
            SceneLoader.Load(_indoorTargetScene);
        }
    }
}
