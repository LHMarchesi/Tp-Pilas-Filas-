using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class BuyingState : IState
{
    private Customers customer;

    public BuyingState(Customers customer)
    {
        this.customer = customer;
    }

    public void Enter()
    {
        customer.ChangeColor(Color.blue);
    }

    public void Update()
    {
        MoveCustomerTowardsObj(customer, SectionManager.instance.GetRandomSection());
    }

    public void MoveCustomerTowardsObj(Customers customer, GameObject obj)
    {
        if (obj != null)
        {
            ContainerManager objScript = obj.GetComponent<ContainerManager>();
            if (objScript.ContainerStack.Count > 0)
            {
                Vector3 endPos;
                endPos = obj.transform.position;
                endPos.y += .60f;

                customer.transform.position = Vector3.MoveTowards(customer.transform.position, endPos, customer.CustomerSpeed * Time.deltaTime);

                if (Vector3.Distance(customer.transform.position, endPos) < customer.InteractDistance)
                {

                    objScript.ContainerRest();
                    customer.StateMachine.TransitionTo(customer.StateMachine.walkingOutState);
                }
            }
        }
    }
    public void Exit() { }
}
