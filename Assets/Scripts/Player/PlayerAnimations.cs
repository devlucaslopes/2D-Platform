using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerAttack attack;
    private Animator animator;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        attack = GetComponent<PlayerAttack>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attack.IsAttacking)
        {
            animator.SetTrigger("attack");
        }

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
