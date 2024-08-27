using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingOutState : IState
{
    private Customers customer;

    public WalkingOutState(Customers customer)
    {
        this.customer = customer;
    }

    public void Enter()
    {
        customer.ChangeColor(Color.red);
    }

    public void Update()
    {
        MoveToEnd();
    }

    public void Exit() { }

    public void MoveToEnd()
    {
        Vector3 endPos;
        endPos = customer.EndPos.transform.position;
        endPos.y += .60f;

        customer.transform.position = Vector3.MoveTowards(customer.transform.position, endPos, customer.CustomerSpeed * Time.deltaTime);

        if (Vector3.Distance(customer.transform.position, endPos) < customer.InteractDistance)
        {
           customer.gameObject.SetActive(false);
        }
    }
}
