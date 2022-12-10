using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _animator;
    
    private string _horizontalMovementFloat = "horizontalMovement";
    private string _verticalMovementFloat = "verticalMovement";
    private string _speedFloat = "speed";

    void Start()
    {
        _playerMovement = PlayerManager.Instance.PlayerMovement;
    }

    public void AnimateCharacter ()
    {
        PlayerStates currentState = _playerMovement.CurrentPlayerState;
    
        _animator.SetFloat(_horizontalMovementFloat, _playerMovement.Movement.x);
        _animator.SetFloat(_verticalMovementFloat, _playerMovement.Movement.y);
        _animator.SetFloat(_speedFloat, _playerMovement.Movement.sqrMagnitude);
        
    }
}
