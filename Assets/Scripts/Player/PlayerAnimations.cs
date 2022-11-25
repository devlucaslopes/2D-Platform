using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerMovement movement;
    private Animator animator;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (movement.IsJumping)
        {
            animator.SetInteger("transition", 2);
        } else if (movement.Direction != 0)
        {
            animator.SetInteger("transition", 1);
        } else
        {
            animator.SetInteger("transition", 0);
        }

        if (movement.Direction > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (movement.Direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
