using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

{
    private Customers customer;
    private CustomerManager customerManager;
    // a que posicion tengo que ir

    private List<Vector3> goinPositions = new List<Vector3>();

    public GoingState(Customers customers)
    {
        this.customer = customers;
    }

    public void Enter()
    {
        customer.ChangeColor(Color.gray);
    }

    public void Update()
    {
    }

    public void Exit() { }


}
