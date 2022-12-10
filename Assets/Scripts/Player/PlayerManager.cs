using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region SINGLETONS
        private static GameObject _playerInstance;
        public static GameObject Player { get { return _playerInstance; } }
        private static PlayerManager _managerInstance;
        public static PlayerManager Manager { get { return _managerInstance; } }
    #endregion

    #region PLAYER COMPONENTS
        public PlayerMovement PlayerMovement;
        public PlayerAnimator PlayerAnimator;
    #endregion
    
    #region MANAGEMENT
        public static bool MovementIsDisabled;
    #endregion

    void Awake()
    {
        HandleSingletons();
        PlayerMovement = this.GetComponent<PlayerMovement>();
        PlayerAnimator = this.GetComponent<PlayerAnimator>();
    }

    void HandleSingletons()
    {
        // Handle PlayerManager instance
        if (_managerInstance != null && _managerInstance != this)
        {
            Destroy(this);
        } else {
            _managerInstance = this;
        }

        // Handle Player gameobject instance
        if (_playerInstance != null && _playerInstance != this.gameObject)
        {
            Destroy(this.gameObject);
        } else {
            _playerInstance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        MovementIsDisabled = false;
    }

    void Update()
    {
        PlayerAnimator.AnimateCharacter();     
    }

    void FixedUpdate()
    {
        if (MovementIsDisabled)
            return;

        PlayerMovement.MoveCharacter();      
    }
}
