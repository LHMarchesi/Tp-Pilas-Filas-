using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : IState
{
    private Customers customer;

    public WaitingState(Customers customer)
    {
        this.customer = customer;
    }
    
    public void Enter()
    {
        customer.ChangeColor(Color.red);
    }
    
    void Update()
    {
        //Logica para la cola de customers
    }
}
