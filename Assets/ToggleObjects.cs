using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    bool isOpen;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isOpen = !isOpen;

                    object1.SetActive(isOpen);
                    object2.SetActive(isOpen);
                }
            }
        }
    }
}