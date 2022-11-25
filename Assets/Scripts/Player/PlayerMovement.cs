using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D body;
    private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(Speed * direction, body.velocity.y);

        if (direction != 0)
        {
            animator.SetInteger("transition", 1);
        } else
        {
            animator.SetInteger("transition", 0);
        }

        if (direction > 0)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
