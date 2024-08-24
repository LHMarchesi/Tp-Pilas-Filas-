using UnityEngine;

public class OnClickHandler : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        OnMouseClick();
    }

    private void OnMouseClick()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Container"))
                {
                    ContainerManager containerManager = hit.transform.GetComponent<ContainerManager>();
                    containerManager.ContainerAdd();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Container"))
                {
                    ContainerManager containerManager = hit.transform.GetComponent<ContainerManager>();
                    containerManager.ContainerRest();
                }
            }
        }
    }
}