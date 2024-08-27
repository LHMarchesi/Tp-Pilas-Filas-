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

    void Update()
    {
        //Logica para la ir al final y destruirse
    }

    public void Exit() { }

    //public void MoveToEnd()
    //{
    //    Vector3 endPos;
    //    endPos = endObj.transform.position;
    //    endPos.y += .60f;

    //    transform.position = Vector3.MoveTowards(transform.position, endPos, customerSpeed * Time.deltaTime);

    //    if (Vector3.Distance(transform.position, endPos) < interactDistance)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
