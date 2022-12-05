using System;
using System.Collections.Generic;
using UnityEngine;

// State machine inspired by this tutorial: https://youtu.be/-VkezxxjsSE
public class CatBaseState
{
    public CatBehaviorStates state;
    public float MinimumTimeInState;
    public float MaximumTimeInState;
    public float LastTimeEnteredState;
    protected CatBehaviorStateMachine _stateMachine;

    public CatBaseState(CatBehaviorStates state, CatBehaviorStateMachine stateMachine, float timeEnteredState, float minTime, float maxTime)
    {
        LastTimeEnteredState = timeEnteredState;
        this.state = state;
        this._stateMachine = stateMachine;
        this.MinimumTimeInState = minTime;
        this.MaximumTimeInState = maxTime;
    }

    public virtual void Enter() { }
    public virtual void UpdateTimeEnteredState(float time) { LastTimeEnteredState = time; }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}

public enum CatBehaviorStates
{
    Idle,
    Eat,
    Sleep,
    Potty
}