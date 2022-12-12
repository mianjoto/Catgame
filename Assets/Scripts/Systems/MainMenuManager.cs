using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    PauseMenu pm;
    bool firstUpdate = true;
    [SerializeField]
    private SceneSwitchData _sceneSwitchData;

    private void Update() {
        if (firstUpdate)
        {
        Debug.Log("infirstupdate");
            firstUpdate =false;
        }
    }
    public void StartGame()
    {
        Debug.Log("Starting game from main menu..");
        SceneLoader.Load(SceneLoader.Scenes.Town, _sceneSwitchData.SceneEntranceName);
    }

    public void Options()
    {
        Debug.Log("Going to options from main menu..");
        pm.GoToOptions();    
    }
    
}
