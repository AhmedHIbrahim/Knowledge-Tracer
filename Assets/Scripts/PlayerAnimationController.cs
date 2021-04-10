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
                myAnimator.Play("Fast Run", -1, 0.0f);
                movementScript.StartMoving();
                isGameStarted = true;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myAnimator.Play("Jump", -1, 0.0f);

            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                myAnimator.Play("Big Jump", -1, 0.0f);

            }

        }



    }
}