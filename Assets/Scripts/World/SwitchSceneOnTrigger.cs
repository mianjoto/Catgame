using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneOnTrigger : MonoBehaviour
{   
    [Tooltip("Scriptable Object that holds the information of which scene to switch to and where to spawn")]
    [SerializeField]
    private SceneSwitchData _sceneSwitchData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneLoader.Load(_sceneSwitchData.TargetScene, _sceneSwitchData.SceneEntranceName);
        }
    }
}
