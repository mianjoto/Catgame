using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject audioOptionsMenu;
    public GameObject gameOverMenu;
    private List<GameObject> allPauseMenus;
    public static bool isPaused;
    string MUSIC_BUTTON_TEXT = "MUSIC: ";
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        allPauseMenus = new List<GameObject>() {pauseMenu, optionsMenu, audioOptionsMenu, gameOverMenu};
    }

    void OnEnable()
    {
        InputListener.OnEscapeKeyDown += TogglePauseResumeGame;
    }
    
    void OnDisable()
    {
        InputListener.OnEscapeKeyDown -= TogglePauseResumeGame;
    }

    private void TogglePauseResumeGame()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        // Disable other pause menus
        optionsMenu.SetActive(false);
        audioOptionsMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    private void SetOnlyActive(GameObject targetMenu)
    {
        foreach (GameObject menu in allPauseMenus)
        {
            if (menu == targetMenu)
                menu.SetActive(true);
            else
                menu.SetActive(false);
        } 
    }

    private void disableAllMenus()
    {
        foreach (GameObject menu in allPauseMenus)
            menu.SetActive(false);
    }

    public void ResumeGame()
    {
        disableAllMenus();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void GoToOptions()
    {
        SetOnlyActive(optionsMenu);
    }
    
    public void GameOver()
    {
        SetOnlyActive(gameOverMenu);
    }
 
    public void GoToAudioOptions()
    {
        SetOnlyActive(audioOptionsMenu);
    }
    
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        string newMusicButtonText;
        if (AudioManager.Instance.musicOn)
            newMusicButtonText = MUSIC_BUTTON_TEXT + "ON";
        else
            newMusicButtonText = MUSIC_BUTTON_TEXT + "OFF";
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneLoader.Load(SceneLoader.Scenes.MainMenu, "MainMenuEntrancePoint", disablePlayerMovement: true);
    }

}
