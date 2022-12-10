using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CatAnimation : MonoBehaviour
{
    private Animator _animator;
    private CatMovement _catMovementHandler;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _catMovementHandler = GetComponent<CatMovement>();
    }
    
    void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        UpdateCatIsMoving();
    }

    void UpdateCatIsMoving()
    {
        bool isCatCurrentlyMoving = _catMovementHandler.IsMoving;
        _animator.SetBool("isCatMoving", isCatCurrentlyMoving);
    }

}
