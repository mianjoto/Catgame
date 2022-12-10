using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    [HideInInspector]
    public PlayerStates CurrentPlayerState { get; set; }

    #region COMPONENTS
        [SerializeField]
        private Animator _animator;
        private PlayerMovement _playerMovement;
    #endregion

    #region KEYS
        private const string HORIZONTAL_MOVEMENT_FLOAT_KEY = "horizontalMovement";
        private const string VERTICAL_MOVEMENT_FLOAT_KEY = "verticalMovement";
        private const string SPEED_FLOAT_KEY = "speed";
    #endregion

    void Start()
    {
        _playerMovement = PlayerManager.Manager.PlayerMovement;
    }

    public void AnimateCharacter ()
    {
        _animator.SetFloat(HORIZONTAL_MOVEMENT_FLOAT_KEY, _playerMovement.Movement.x);
        _animator.SetFloat(VERTICAL_MOVEMENT_FLOAT_KEY, _playerMovement.Movement.y);
        _animator.SetFloat(SPEED_FLOAT_KEY, _playerMovement.Movement.sqrMagnitude);
    }

    public void SetPlayerState(PlayerStates newState)
    {
        CurrentPlayerState = newState;
    }
}
