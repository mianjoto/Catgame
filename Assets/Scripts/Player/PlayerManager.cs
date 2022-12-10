using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public PlayerAnimator PlayerAnimator;

    void Start()
    {
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
