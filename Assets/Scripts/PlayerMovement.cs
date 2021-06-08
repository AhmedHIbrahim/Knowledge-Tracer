using UnityEngine;
using UnityEngine.UI;

// attach the script to the player
public class PlayerMovement : MonoBehaviour
{
    public Text textHints;
    public float runSpeed = 60f;
    public float jumpSpeed = 9f;
    public float gravity = 9.81f;
    public float laneWidth = 2.5f;
    public float smooth;

    public float minRunSpeed = 60f;
    public float maxRunSpeed = 120f;
    public float accelerationTime = 180f;
    private float time;

    CharacterController controller;
    Vector3 direction;
    float directionY;
    bool isMoveStarted = false;
    int lane = 1;  // 0:left 1:middle 2:righ;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        direction = new Vector3(0, 0, 0);
        time = 0;

    }


    void Update()
    {

        if (isMoveStarted)
        {

            runSpeed = Mathf.SmoothStep(minRunSpeed, maxRunSpeed, time / accelerationTime);

            time += Time.deltaTime;

            ProcessUserInput();
            direction.z = runSpeed * Time.deltaTime;
            HandleSliding();
            Run();


        }
        else
        {
            textHints.SendMessage("ShowHint", "Press Enter to start the game ... ");
        }


    }


    void LateUpdate()
    {
        UpdateXPosition();
    }

    void Jump()
    {
        directionY = jumpSpeed;
    }

    void Run()
    {

        directionY -= gravity * Time.deltaTime;
        direction.y = directionY;
        controller.Move(direction * Time.deltaTime);
    }

    void StartMoving()
    {
        isMoveStarted = true;
        GameObject.Find("TileManager").SendMessage("PlayEnvironmentSound");
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

        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, smooth * Time.deltaTime);

    }

    void HandleSliding()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            controller.height = 1.5f;
            Vector3 tempCenter = controller.center;
            tempCenter.y = controller.height / 2;
            controller.center = tempCenter;
            Invoke("SetCenter", 2f);

        }

    }


    void SetCenter()
    {
        controller.height = 3.64f;
        Vector3 tempCenter = controller.center;
        tempCenter.y = 1.91f;
        controller.center = tempCenter;

    }

    void UpdateRunSpeed()
    {
        runSpeed = runSpeed + 1;
    }

}