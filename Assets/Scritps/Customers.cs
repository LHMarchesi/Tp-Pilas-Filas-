using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour
{
    private StateMachine stateMachine;
    private float customerSpeed = 2.0f;
    private float interactDistance = 0.01f;
    public float CustomerSpeed => customerSpeed;
    public float InteractDistance => interactDistance;
    public StateMachine StateMachine => stateMachine;

    [SerializeField] private GameObject endPos;
    public GameObject EndPos => endPos;


    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
        stateMachine = new StateMachine(this);
    }

    private void Start()
    {
        stateMachine.Initialize(stateMachine.buyingState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void ChangeColor(Color color)
    {
        mesh.material.color = color;
    }
}
