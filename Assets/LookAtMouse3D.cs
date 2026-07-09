using UnityEngine;

public class LookAtMouseOrthographic : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        // Cache the main camera for performance
        cam = Camera.main;
    }

    void Update()
    {
        // 1. Get the mouse position in pixel coordinates
        Vector3 mousePos = Input.mousePosition;

        // 2. Set the Z distance to the gap between the camera and the object
        // This is crucial for Orthographic cameras to calculate world position correctly
        mousePos.z = Mathf.Abs(cam.transform.position.y - transform.position.y);

        // 3. Convert the 2D mouse position into a 3D world point
        Vector3 targetPoint = cam.ScreenToWorldPoint(mousePos);

        // 4. Force the target point to be on the same height (Y-axis) as the object
        // This stops the object from tilting up/down
        targetPoint.y = transform.position.y;

        // 5. Calculate the direction and rotate on the Y-axis only
        Vector3 direction = targetPoint - transform.position;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}