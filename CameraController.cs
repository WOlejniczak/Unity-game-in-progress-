
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Serialize mens that rhis field can occur in inspectior
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        MyInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {

        //getting input from mouse X and Y

        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");


        //yRotiation which is left rigt = our mouse input * sens
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
