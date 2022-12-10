using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneOnTrigger: MonoBehaviour
{
    [Header("Scene that the player should switch to upon trigger")]
    [SerializeField]
    private Scenes _targetScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(_targetScene);
        }
    }
}