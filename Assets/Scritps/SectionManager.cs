using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    [SerializeField] private GameObject sectionObj;
    [SerializeField] private int totalSections;
    private List<GameObject> SectionList = new List<GameObject>();
    private Vector3 startPosition;
    private Vector3 offset = new Vector3(1.5f, 0, 0);

    void Start()
    {
        startPosition = this.transform.position; //Toma la posicion del container y la ajusta

        for (int i = 0; i < totalSections; i++)
        {
                Vector3 newPos = startPosition + offset * SectionList.Count; // a la posicion incial le suma el offset y lo multiplica por la canitidad de items dentro de la lista
                GameObject item = Instantiate(sectionObj, newPos, Quaternion.identity, this.transform);
                SectionList.Add(item);
        }
    }
}
