using UnityEngine;

// attach the script to the player
public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 110f;
    public float jumpSpeed = 9f;
    public float gravity = 9.81f;
    public float laneWidth = 2.5f;
    public float smooth;

    CharacterController controller;
    float directionY;
    bool isMoveStarted = false;


    int lane = 1;  // 0:left 1:middle 2:righ;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {

        if (isMoveStarted)
        {

            Vector3 direction = new Vector3(0, 0, 0);

            ProcessUserInput();
            direction.z = runSpeed * Time.deltaTime;

            HandleSliding();

            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.UpArrow)
                )
            {

                if (controller.isGrounded && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FastRun"))
                {
                    directionY = jumpSpeed;
                }


            }

            directionY -= gravity * Time.deltaTime;

            direction.y = directionY;

            controller.Move(direction * Time.deltaTime);
        }

    }

    private void LateUpdate()
    {
        UpdateXPosition();
    }

    public void StartMoving()
    {
        isMoveStarted = true;
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
    void UpdateXPosition()
    {

        if (!controller.isGrounded)
        {
            return;
        }
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
        controller.center = controller.center;

    }

    void HandleSliding()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            controller.height = 1.5f;
            Vector3 tempCenter = controller.center;
            tempCenter.y = controller.height / 2;
            controller.center = tempCenter;

        }
        else
        {
            Invoke("SetCenter", 3000f);

        }
    }


    void SetCenter()
    {

        Vector3 tempCenter = controller.center;
        tempCenter.y = 1.91f;
        controller.center = tempCenter;

        controller.height = 3.64f;

    }



}