using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammm : MonoBehaviour
{ 
      Rigidbody rb;
    public GameObject PLAYER;

    public Transform cam;
public float speed = 6f;

public float turnSmoothTime = 0.1f;
float turnSmoothVelocity;

    bool isGrounded;
    float jumpForce = -15f;

    // Start is called before the first frame update
    void Update()
    {
       

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.01f);

        Vector3 inputVector = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputVector.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputVector.x, inputVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.velocity = moveDir.normalized * speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
