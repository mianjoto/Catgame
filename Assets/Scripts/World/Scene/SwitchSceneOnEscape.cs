using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneOnEscape : MonoBehaviour
{
    [SerializeField]
    private SceneSwitchData _sceneSwitchData;

    void OnEnable()
    {
        InputListener.OnEscapeKeyDown += SwitchToScene;
    }
    void OnDisable()
    {
        InputListener.OnEscapeKeyDown -= SwitchToScene;
    }

    private void SwitchToScene()
    {
        SceneLoader.Load(
            _sceneSwitchData.TargetScene,
            _sceneSwitchData.SceneEntranceName,
            disablePlayerMovement: false);
    }
}
