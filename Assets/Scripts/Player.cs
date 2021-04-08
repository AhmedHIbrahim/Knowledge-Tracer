using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator myAnim;

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.Play("Big Jump", -1, 0.0f);

        }

    }
}
