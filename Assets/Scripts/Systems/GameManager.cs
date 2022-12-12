using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETONS
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }
    #endregion

    #region DATA
        [SerializeField]
        private SceneSwitchData _gameOverSwitchSceneData;       
    #endregion

    private void Awake()
    {
        HandleSingleton();
    }

    void HandleSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this);
            _instance = this;
        }
    }

    void OnEnable()
    {
        StatusBar.OnStatusBarEmpty += GameOver;
    }
    void OnDisable()
    {
        StatusBar.OnStatusBarEmpty += GameOver;
    }

    private void GameOver(StatusBar obj)
    {
        SceneLoader.Load(SceneLoader.Scenes.GameOver, "GameOverEntrancePOint", true);
    }

    public static void DisablePlayerMovement() => PlayerManager.MovementIsDisabled = true;
    public static void EnablePlayerMovement() => PlayerManager.MovementIsDisabled = false;

}
