using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private int maxItems;
    private Stack<GameObject> containerStack = new Stack<GameObject>();
    private Vector3 startPosition;
    private Vector3 offset = new Vector3(0, 0, .1f);
    public Stack<GameObject> ContainerStack => containerStack;

    private void Start()
    {
        startPosition = this.transform.position; //Toma la posicion del container y la ajusta
        startPosition.y += .4f;
        startPosition.z -= .4f;
    }

    public void ContainerAdd()
    {
        if (containerStack.Count < maxItems)
        {
            Vector3 newPos = startPosition + offset * containerStack.Count; // a la posicion incial le suma el offset y lo multiplica por la canitidad de items dentro del stack
            GameObject item = Instantiate(this.item, newPos, Quaternion.identity);
            containerStack.Push(item);
        }
    }
    public void ContainerRest()
    {
        if (containerStack.Count > 0)
        {
            GameObject item = containerStack.Pop();
            Destroy(item); // Destruye el objeto despu�s de sacarlo de la pila
        }
    }
}