//using UnityEngine;

//public class HeadLookMouse : MonoBehaviour
//{
//    public Camera cam;
//    public float distanceFromCamera = 5f;
//    public float rotationSpeed = 8f;
//    public Vector3 offsetEuler; // tune this ONE field until it looks right

//    void Start()
//    {
//        if (cam == null) cam = Camera.main;
//    }

//    void Update()
//    {
//        Vector3 mouse = Input.mousePosition;
//        mouse.z = distanceFromCamera;
//        Vector3 worldPoint = cam.ScreenToWorldPoint(mouse);

//        transform.LookAt(-worldPoint*2);
//        transform.rotation *= Quaternion.Euler(offsetEuler);
//    }
//}
using UnityEngine;
public class HeadLookMouse : MonoBehaviour
{
    public Camera cam;
    public float distanceFromCamera = 5f;
    public float rotationSpeed = 8f;
    public float sensitivity = 2f; // increase this to make it more sensitive
    public Vector3 offsetEuler;
    public float leftBias = 50f; // pixels to shift left, tune this
    void Start()
    {
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        //Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        //Vector3 mouseOffset = (Vector3)Input.mousePosition - screenCenter;
        //Vector3 mouse = screenCenter + mouseOffset * sensitivity;
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        Vector3 mouseOffset = (Vector3)Input.mousePosition - screenCenter;
        mouseOffset.x -= leftBias; // shifts the tracking point left

        Vector3 mouse = screenCenter + mouseOffset * sensitivity;

        mouse.z = distanceFromCamera;
        Vector3 worldPoint = cam.ScreenToWorldPoint(mouse);

        transform.LookAt(-worldPoint * 2);
        transform.rotation *= Quaternion.Euler(offsetEuler);
    }
}