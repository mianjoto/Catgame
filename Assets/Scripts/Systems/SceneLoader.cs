
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SceneLoader : MonoBehaviour
{
    public enum Scenes
    {
        Loading,
        Town,
        Dashboard,
        House
    }

    private static Action OnLoaderCallback;

    public static void Load(SceneLoader.Scenes scene)
    {   
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
}

