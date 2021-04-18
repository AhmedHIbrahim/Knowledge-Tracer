using UnityEngine;

// attach the script to the player
public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed = 5f;
    public float runSpeed = 1f;
    public float _jumpSpeed = 3.5f;
    public float _gravity = 9.81f;

    private float _directionY;
    private CharacterController _controller;

    bool isMoveStarted = false;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);



        if (isMoveStarted)
        {
            direction.z = runSpeed;


            if (Input.GetButtonDown("Jump"))
            {
                _directionY = _jumpSpeed;
            }
        }
        _directionY -= _gravity * Time.deltaTime;

        direction.y = _directionY;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }



    public void StartMoving()
    {
        isMoveStarted = true;
    }


}
