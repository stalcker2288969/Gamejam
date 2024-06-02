using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput > 0 || horizontalInput < 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.Play("Stay");
        }
    }
}
