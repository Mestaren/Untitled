using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed = 6f;

    float Horizontalmove;
    float VerticalMove;

    Vector3 moveDirection;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        Horizontalmove = Input.GetAxisRaw("Horizontal");
        VerticalMove = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * VerticalMove + transform.right * Horizontalmove;

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * MoveSpeed, ForceMode.Acceleration);
    }
}
