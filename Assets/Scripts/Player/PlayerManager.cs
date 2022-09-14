using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController PlayerController;
    public PlayerAnimator PlayerAnimator;

    void Start()
    {
        PlayerController = this.GetComponent<PlayerController>();
        PlayerAnimator = this.GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        PlayerController.MoveCharacter();      
        PlayerAnimator.AnimateCharacter();     
    }
}
