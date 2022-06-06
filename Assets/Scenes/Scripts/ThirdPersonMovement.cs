using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    Rigidbody rb;
    public Transform cam;
    public float speed = 6f;
    

    public float turnSmoothTIme = 0.1f;
    float turnSmoothVelocity;
    private bool isGrounded;
    private int layerMask;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
     
        rb.freezeRotation = true;
    }


    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.01f, layerMask);


        Vector3 inputVector = new Vector3 (horizontal, 0f, vertical).normalized;


        if(inputVector.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(inputVector.x, inputVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, turnSmoothTIme);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
          Vector3 moveDir = new Vector3(transform.forward.x, rb.velocity.y, transform.forward.z);
           rb.velocity = moveDir.normalized * speed;
        }
    }
}
