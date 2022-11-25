using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D body;
    private Animator animator;

    private bool _isJumping;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !_isJumping)
        {
            _isJumping = true;
            body.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

            animator.SetInteger("transition", 2);
        }
    }

    private void Movement()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(Speed * direction, body.velocity.y);

        if (!_isJumping)
        {
            if (direction != 0)
            {
                animator.SetInteger("transition", 1);
            }
            else
            {
                animator.SetInteger("transition", 0);
            }
        }

        if (direction > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isJumping = false;
        }
    }
}
