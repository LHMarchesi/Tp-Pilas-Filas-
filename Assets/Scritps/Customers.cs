using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    private float customerSpeed = 2.0f;
    public float CustomerSpeed => customerSpeed;
    private MeshRenderer mesh;
    public GameObject startPos;
    public GameObject endPos;

    private StateMachine stateMachine;
    public StateMachine StateMachine => stateMachine;

    private void Awake()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
        stateMachine = new StateMachine(this);

    }

    void Start()
    {
        stateMachine.Initialize(stateMachine.waitingState);
    }

    void Update()
    {
        stateMachine.Update();
    }

    public void ChangeColor(Color color)
    {
        mesh.material.color = color;
    }
}
