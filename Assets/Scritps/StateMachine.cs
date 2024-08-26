using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine 
{
    private IState currentState;
    public IState CurrentState => currentState;

    public WaitingState waiting;
    //public BuyingState buying;
    //public WalkingOutState walkingOut;

    public StateMachine(Customers customer)
    {
        waiting = new WaitingState(customer);
        //buying = new BuyingState(customer);
        //walkingOut = new WalkingOutState(customer);
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
        if(currentState !=null)
        {
            currentState.Update();
        }
    }
}
