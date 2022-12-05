using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField]
    public CatBaseState CurrentState;
    public float _timeToLeaveIdleState; // TODO: make this private

    void Start()
    {
        CurrentState = GetInitialState();
        if (CurrentState != null)
            CurrentState.Enter();
        CurrentState.LastTimeEnteredState = Time.time;
        _timeToLeaveIdleState = GetRandomIdleStateLeaveTime();
    }

    public void ChangeState(CatBaseState newState, float timeEnteredState)
    {   
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.UpdateTimeEnteredState(timeEnteredState);
        _timeToLeaveIdleState = GetRandomIdleStateLeaveTime();
        CurrentState.Enter();
    }

    public virtual void ChangeToRandomState()
    {
        return;
    }

    protected virtual CatBaseState GetInitialState()
    {
        return null;
    }



    /// <summary>
    /// Returns a random time between the minumum and maximum time,
    /// which hints when the cat should transition to another state.
    /// </summary>
    /// <returns></returns>
    private float GetRandomIdleStateLeaveTime()
    {
        float timeToSpendInState = UnityEngine.Random.Range(CurrentState.MinimumTimeInState, CurrentState.MaximumTimeInState);
        Debug.Log($"TimeToSpendInState={timeToSpendInState}");
        float timeToLeaveState = CurrentState.LastTimeEnteredState + timeToSpendInState;
        return timeToLeaveState;
    }

    
}