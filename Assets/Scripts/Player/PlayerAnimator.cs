using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Animator _animator;
    
    private string _horizontalMovementFloat = "horizontalMovement";
    private string _verticalMovementFloat = "verticalMovement";
    private string _speedFloat = "speed";

    void Start()
    {
        _controller = this.GetComponent<PlayerManager>().PlayerController;
    }

    public void AnimateCharacter ()
    {
        PlayerStates currentState = _controller.CurrentPlayerState;
    
        _animator.SetFloat(_horizontalMovementFloat, _controller.Movement.x);
        _animator.SetFloat(_verticalMovementFloat, _controller.Movement.y);
        _animator.SetFloat(_speedFloat, _controller.Movement.sqrMagnitude);
        
    }
}
