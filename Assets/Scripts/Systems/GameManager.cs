using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETONS
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        HandleSingleton();
        HandleDontDestroys();
    }

    void HandleSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void HandleDontDestroys()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(PlayerManager.Player);
    }
}
