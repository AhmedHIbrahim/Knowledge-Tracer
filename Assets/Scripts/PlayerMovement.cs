using UnityEngine;

// attach the script to the player
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;

    bool isMoveStarted = false;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (isMoveStarted)
        {
            Move();
        }

    }

    public void StartMoving()
    {
        isMoveStarted = true;
    }

    void Move()
    {
        // transform.forwad is z
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

}
