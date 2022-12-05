using System;
using UnityEngine;

public class CatIdleState : CatBaseState
{
    public CatIdleActions IdleAction;
    private Animator _catAnimator;
    private CatMovement _catMovementController;
    private Animation _idleAnimation;
    // Add cat walk function here
    private Animation _faceAwayAnimation;
    private Animation _sleepAnimation;
    private bool hasWalked;

    public CatIdleState(CatBehaviorStateMachine stateMachine, Animator catAnimator, CatMovement catMovementController) : 
        base(CatBehaviorStates.Idle, stateMachine, Time.time, 3f, 10f)
    {
        _catAnimator = catAnimator;
        _catMovementController = catMovementController;
    }

    public override void Enter()
    {
        base.Enter();
        // IdleAction = GetRandomIdleAction(); TODO: Uncomment this
        hasWalked = false;
        IdleAction = CatIdleActions.Walk;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        switch (IdleAction)
        {
            case CatIdleActions.Idle:
                RunIdle();
                break;
            case CatIdleActions.Walk:
                if (!hasWalked)
                    RunWalk();
                break;
            case CatIdleActions.FaceAway:
                RunFaceAway();
                break;
            case CatIdleActions.Sleep:
                RunSleep();
                break;
        }
    }

    private void RunIdle()
    {
       
    }

    private void RunWalk()
    {
        if (hasWalked)
            return;

        float distanceScalar = 3f;
        Vector2 randomPosition = UnityEngine.Random.insideUnitCircle * distanceScalar;
        _catMovementController.MoveCat(randomPosition, 5f);
        hasWalked = true;
    }

    private void RunFaceAway()
    {
    }

    private void RunSleep()
    {
    }

    private CatIdleActions GetRandomIdleAction()
    {
        Array actions = Enum.GetValues(typeof(CatIdleActions));
        int randomActionIndex = UnityEngine.Random.Range(0, actions.Length);
        return (CatIdleActions) actions.GetValue(randomActionIndex);
    }

    
}

public enum CatIdleActions
{
    Idle,
    Walk,
    Sleep,
    FaceAway
}