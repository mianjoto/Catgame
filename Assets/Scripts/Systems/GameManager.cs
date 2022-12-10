using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETONS
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }
        [SerializeField] public static GameObject Player;
    #endregion

    private void Awake()
    {
        HandleSingleton();
        HandleDontDestorys();
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

    private void HandleDontDestorys()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Player);
    }
}
