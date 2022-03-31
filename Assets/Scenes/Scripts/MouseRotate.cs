using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    
    public float mouseSensetivity = 100f;
    public Transform playerBody;
    float Xrotation = 0f;
    float Yrotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Xrotation, Yrotation, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
