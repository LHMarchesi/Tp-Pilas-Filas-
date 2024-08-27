using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : IState
{
    private Customers customer;
    private CustomerManager customerManager;

    public WaitingState(Customers customer)
    {
        this.customer = customer;
    }

    public void Enter()
    {
        customer.ChangeColor(Color.green);
        customerManager = GameObject.FindAnyObjectByType<CustomerManager>();
    }


    public void Update()
    {
        OnWaiting(SectionManager.instance.GetRandomSection());
    }

    private void OnWaiting(GameObject container) // Espera que haya un container por pickear
    {
        if (container != null)
        {
            customer.StateMachine.TransitionTo(customer.StateMachine.buyingState);
        }
        else
        {
            Vector3 waitingPos;
            waitingPos = customer.WaitingPos.transform.position;
            waitingPos.y += .60f;
            customer.transform.position = Vector3.MoveTowards(customer.transform.position, waitingPos, customer.CustomerSpeed * Time.deltaTime); // Lo manda a la posicion de espera
        }
    }

    public void Exit() { }


}
