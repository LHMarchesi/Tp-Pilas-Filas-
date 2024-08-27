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
        //Logica para la cola de customers
        MoveToStart();
    }

    public void MoveToStart()
    {
        //if (customerManager.customerQeue.Peek() == customer)
        //{
            Vector3 startPos;
            startPos = customer.StartPos.transform.position;
            startPos.y += .60f;

            customer.transform.position = Vector3.MoveTowards(customer.transform.position, startPos, customer.CustomerSpeed * Time.deltaTime);

            if (Vector3.Distance(customer.transform.position, startPos) < customer.InteractDistance)
            {
                customer.StateMachine.TransitionTo(customer.StateMachine.buyingState);
            }
        //}
    }

    public void Exit() { }
}
