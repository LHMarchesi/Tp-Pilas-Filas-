using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingState : IState
{
    private Customers customer;

    public BuyingState(Customers customer)
    {
        this.customer = customer;
    }

    public void Enter()
    {
        customer.ChangeColor(Color.red);
    }

    void Update()
    {
        //Logica para buscar un item
    }

    public void Exit() { }
}
