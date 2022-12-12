
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SceneLoader : MonoBehaviour
{
    public static string NEXT_SCENE_ENTER_POINT_KEY = "NextSceneEnterPoint";
    private static Action OnLoaderCallback;

    public static void Load(SceneLoader.Scenes scene, string targetSceneEnterPointName, bool disablePlayerMovement = false)
    {
        if (disablePlayerMovement)
            GameManager.DisablePlayerMovement();
        else
            GameManager.EnablePlayerMovement();
        
        PlayerPrefs.SetString(NEXT_SCENE_ENTER_POINT_KEY, targetSceneEnterPointName);
        
        // Load the target scene after the callback
        OnLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        // Load the loading scene
        SceneManager.LoadScene(Scenes.Loading.ToString());
    }


    public static void LoaderCallback() {
        if (OnLoaderCallback != null)
        {
            OnLoaderCallback();
            OnLoaderCallback = null;
        }
    }

    // Temporary--only for testing
    public static void LoadMainMenu()
    {
        Load(Scenes.MainMenu, "MainMenuEnterPoint", true);
    }

    public enum Scenes
    {
        Loading,
        Town,
        Dashboard,
        House,
        MainMenu,
        GameOver
    }

}

