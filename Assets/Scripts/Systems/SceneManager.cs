
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private SceneManager instance;

    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(scene);
    }    
}

public enum Scenes
{
    Town,
    Dashboard,
    House
}