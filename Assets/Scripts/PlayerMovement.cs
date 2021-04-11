using UnityEngine;

// attach the script to the player
public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Vector3 runDirection;
    public float runSpeed = 5;

    int lane = 1;  // 0:left 1:middle 2:right
    public float laneWidth = 2.5f;
    public float smooth;

    bool isMoveStarted = false;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isMoveStarted)
        {
            ProcessUserInput();
        }

    }

    void FixedUpdate()
    {
        if (isMoveStarted)
        {
            Run();
        }

    }

    private void LateUpdate()
    {
        CalculateNewXPosition();
    }

    public void StartMoving()
    {
        isMoveStarted = true;
    }

    void Run()
    {
        runDirection.z = runSpeed;
        characterController.Move(runDirection * Time.fixedDeltaTime);
    }

    void ProcessUserInput()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && lane > 0)
        {
            lane--;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && lane < 2)
        {
            lane++;
        }


    }

    void CalculateNewXPosition()
    {
        Vector3 newPosition = transform.localPosition.z * transform.forward + transform.localPosition.y * transform.up;
        if (lane == 0)
        {
            newPosition += Vector3.left * laneWidth;
        }
        else if (lane == 2)
        {
            newPosition += Vector3.right * laneWidth;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, smooth);
        characterController.center = characterController.center;

    }

}
