using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    public float customerSpeed = 2.0f;
    public float interactDistance = 0.25f;

    public GameObject startObj;
    public GameObject endObj;
    private Vector3 startPos;

    void Start()
    {
        startPos = startObj.transform.position;
        startPos.y += .60f;
        transform.position = startPos;


    }

    void Update()
    {
        MoveToEnd();
    }

    public void MoveToEnd()
    {
        Vector3 endPos;
        endPos = endObj.transform.position;
        endPos.y += .60f;

        transform.position = Vector3.MoveTowards(transform.position, endPos, customerSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, endPos) < interactDistance)
        {
            Destroy(gameObject);
        }
    }
}
