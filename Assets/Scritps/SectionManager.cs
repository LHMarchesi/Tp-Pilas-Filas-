using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public static SectionManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<GameObject> SectionList => sectionList;
    [SerializeField] private GameObject sectionObj;
    [SerializeField] private int totalSections;

    private List<GameObject> sectionList = new List<GameObject>();
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

    public GameObject GetRandomSection() // Toma una seccion random disponible
    {
        List<GameObject> nonEmptySections = new List<GameObject>();

        foreach (GameObject section in SectionList)
        {
            ContainerManager containerManager = section.GetComponent<ContainerManager>();
            if (containerManager.ContainerStack.Count > 0)
            {
                nonEmptySections.Add(section);
            }
        }

        if (nonEmptySections.Count == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, nonEmptySections.Count);
        return nonEmptySections[randomIndex];
    }
}
