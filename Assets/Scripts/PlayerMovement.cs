using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;

    Vector3 forwardMove;
    Vector3 horizontalMove;
    private void FixedUpdate()
    {
        forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
