using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    private IState currentState;
    public IState CurrentState => currentState;

    public WaitingState waitingState;
    public BuyingState buyingState;
    public WalkingOutState walkingOutState;

    public StateMachine(Customers customer)
    {
        waitingState = new WaitingState(customer);
        buyingState = new BuyingState(customer);
        walkingOutState = new WalkingOutState(customer);
    }

    public void Initialize(IState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        currentState.Enter();

    }

    public void Update()
    {
        currentState.Update();
    }
}
