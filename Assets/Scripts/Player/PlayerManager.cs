using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement PlayerController;
    public PlayerAnimator PlayerAnimator;

    void Start()
    {
        PlayerController = this.GetComponent<PlayerMovement>();
        PlayerAnimator = this.GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        PlayerAnimator.AnimateCharacter();     
    }

    void FixedUpdate()
    {
        PlayerController.MoveCharacter();      
    }
}
