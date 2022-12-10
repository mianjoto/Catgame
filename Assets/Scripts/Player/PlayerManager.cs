using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region SINGLETONS
        private static PlayerManager _instance;
        public static PlayerManager Instance { get { return _instance; } }
    #endregion

    #region PLAYER COMPONENTS
        public PlayerMovement PlayerMovement;
        public PlayerAnimator PlayerAnimator;
    #endregion

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        PlayerMovement = this.GetComponent<PlayerMovement>();
        PlayerAnimator = this.GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        PlayerAnimator.AnimateCharacter();     
    }

    void FixedUpdate()
    {
        PlayerMovement.MoveCharacter();      
    }
}
