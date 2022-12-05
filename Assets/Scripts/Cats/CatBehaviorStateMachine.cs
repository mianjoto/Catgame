using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(CatMovement))]
public class CatBehaviorStateMachine : BaseStateMachine
{
    #region States
        [SerializeField]
        private List<CatBaseState> _allStates;
        [HideInInspector]
        public CatIdleState IdleState;
        [HideInInspector]
        public CatEatState EatState;
    #endregion
    #region Components
        [SerializeField]
        private Animator _animatorController;
        [SerializeField]
        private CatMovement _catMovementController;
    #endregion

    void Awake()
    {
        IdleState = new CatIdleState(this, _animatorController, _catMovementController);
        EatState = new CatEatState(this);
        _allStates = new List<CatBaseState>();
        _allStates.Add(IdleState);
        _allStates.Add(EatState);
    }

    void Update()
    {
        if (CurrentState != null)
            CurrentState.UpdateLogic();
        if (Time.time > _timeToLeaveIdleState)
            ChangeToRandomState();
    }

    void LateUpdate()
    {
        if (CurrentState != null)
            CurrentState.UpdatePhysics();
    }

    protected override CatBaseState GetInitialState()
    {
        return IdleState;
    }

    public override void ChangeToRandomState()
    {
        print($"Current state={CurrentState}");
        CatBaseState randomState = GetRandomState();
        ChangeState(randomState, Time.time);
        print($"Swapped to={CurrentState}");
    }

    private CatBaseState GetRandomState()
    {
        CatBaseState randomState = CurrentState;
        while (randomState == CurrentState)
        {
            int randomStateNumber = UnityEngine.Random.Range(0, _allStates.Count);
            randomState = _allStates[randomStateNumber];
        }
        return randomState;
    }
    
}

