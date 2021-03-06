using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator myAnimator;
    bool isGameStarted = false;


    void Start()
    {
        myAnimator = GetComponent<Animator>();

    }

    public void StartAnimation()
    {
        if (!isGameStarted)
        {
            myAnimator.Play("FastRun", -1, 0.0f);
            gameObject.SendMessage("StartMoving");
            isGameStarted = true;

        }
    }

    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                StartAnimation();
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
                gameObject.SendMessage("Jump");

            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myAnimator.Play("RunningJump", -1, 0.0f);
                gameObject.SendMessage("Jump");

            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                myAnimator.Play("Sliding", -1, 0.0f);

            }


        }


    }

}
