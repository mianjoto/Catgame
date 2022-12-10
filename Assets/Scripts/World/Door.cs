using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{   
    [Tooltip("Scriptable Object that holds the information of which scene to switch to and where to spawn")]
    [SerializeField]
    private SceneSwitchData _sceneSwitchData;

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
            SceneLoader.Load(_sceneSwitchData.TargetScene, _sceneSwitchData.SceneEntranceName);
        }
    }
}
