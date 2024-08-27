using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    public Stack<GameObject> customerQeue = new Stack<GameObject>();
    private int maxCustomers = 5;
    private Vector3 spawnPos = new Vector3(-10, .60f, -1);
    private Vector3 offset = new Vector3(-2, 0, 0);

    void Start()
    {
        StartCoroutine(SpawnCustomers());
    }

    IEnumerator SpawnCustomers()
    {
        while (customerQeue.Count < maxCustomers)
        {
            AddCustomer();
            yield return new WaitForSeconds(5f);
        }
    }

    public void AddCustomer()
    {
        if (customerQeue.Count < maxCustomers)
        {
            GameObject item = Instantiate(customer, spawnPos, Quaternion.identity);
            customerQeue.Push(item);
            //MoveTowardsLastCustomer(item);
        }
    }

    public void MoveTowardsLastCustomer(GameObject item)
    {
        GameObject lastCustomer = customerQeue.Peek();
        Customers customerScript = item.GetComponent<Customers>();

        Vector3 newPos = lastCustomer.transform.position + offset * customerQeue.Count;
        item.transform.position = Vector3.MoveTowards(item.transform.position, newPos, customerScript.CustomerSpeed * Time.deltaTime);

    }



}
