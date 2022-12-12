using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneOnInteract : Interactable
{   
    [Tooltip("Scriptable Object that holds the information of which scene to switch to and where to spawn")]
    [SerializeField]
    private SceneSwitchData _sceneSwitchData;
    [SerializeField]
    private bool _disablePlayerMovement;

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
            SceneLoader.Load(_sceneSwitchData.TargetScene, _sceneSwitchData.SceneEntranceName, _disablePlayerMovement);
        }
    }
}
