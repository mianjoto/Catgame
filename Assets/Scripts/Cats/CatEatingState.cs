using System;
using UnityEngine;

public class CatEatState : CatBaseState
{
    public CatEatState(CatBehaviorStateMachine stateMachine) : base(CatBehaviorStates.Eat, stateMachine, Time.time, 6f, 12f) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

}