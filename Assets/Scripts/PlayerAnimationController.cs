using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator myAnimator;
    bool isGameStarted = false;
    PlayerMovement movementScript;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        movementScript = gameObject.GetComponent<PlayerMovement>();

    }

    void Update()
    {

        if (!isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                myAnimator.Play("FastRun", -1, 0.0f);
                movementScript.StartMoving();
                isGameStarted = true;

            }
        }
        else
        {
            // it won't allow an animation to play while another animation is playing
            if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("FastRun"))
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                myAnimator.Play("JumpOverStart", -1, 0.0f);


            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myAnimator.Play("RunningJump", -1, 0.0f);


            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                myAnimator.Play("Sliding", -1, 0.0f);


            }


        }



    }

}
