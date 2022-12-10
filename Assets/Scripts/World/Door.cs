using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{   
    [Tooltip("Scriptable Object that holds the information of which scene to switch to and where to spawn")]
    [SerializeField]
    private SceneSwitchData _sceneSwitchData;

    void Update()
    {
        Interact();
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(GameManager.InteractKey) && CanInteract)
        {
            SceneLoader.Load(_sceneSwitchData.TargetScene, _sceneSwitchData.SceneEntranceName);
        }
    }
}
