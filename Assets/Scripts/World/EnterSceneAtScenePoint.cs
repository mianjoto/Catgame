using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneAtScenePoint : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString(SceneLoader.NEXT_SCENE_ENTER_POINT_KEY) == this.gameObject.name)
        {
            print($"GOING TO TP TO {this.gameObject.name}'s position");
            GameManager.Player.transform.position = this.transform.position;
        }        
    }
}
