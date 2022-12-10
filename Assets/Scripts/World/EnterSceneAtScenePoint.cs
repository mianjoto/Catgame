using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneAtScenePoint : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString(SceneLoader.NEXT_SCENE_ENTER_POINT_KEY) == this.gameObject.name)
        {
            PlayerManager.Player.transform.position = this.transform.position;
        }        
    }
}
