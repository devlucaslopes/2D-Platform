using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D body;

    private float _direction;
    private bool _isJumping;
    private bool _lookToRight = true;

    public bool LookToRight { get => _lookToRight; }
    public float Direction { get => _direction; }
    public bool IsJumping { get => _isJumping; }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        }
    }

    private void Movement()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(Speed * _direction, body.velocity.y);

        if (_direction > 0)
        {
            _lookToRight = true;
        } else if (_direction < 0)
        {
            _lookToRight = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _isJumping = false;
        }

        if (collision.transform.CompareTag("Moving Platform"))
        {
            if (transform.position.y > collision.transform.position.y)
            {
                transform.SetParent(collision.transform);
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Moving Platform"))
        {
            transform.SetParent(null);
        }
    }
}
