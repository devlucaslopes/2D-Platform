using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;

    [Header("Ground Detector")]
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private Transform GroundPoint;
    [SerializeField] private Vector3 GroundPointOffset;
    [SerializeField] private float RaycastRange;

    private Rigidbody2D body;

    private bool _isJumping;
    private bool _isGrounded;

    private float _direction;
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
        CheckIsGrounded();

        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckIsGrounded()
    {
        RaycastHit2D rightFoot = Physics2D.Raycast(GroundPoint.position + GroundPointOffset, Vector2.down, RaycastRange, GroundMask);
        RaycastHit2D leftFoot = Physics2D.Raycast(GroundPoint.position - GroundPointOffset, Vector2.down, RaycastRange, GroundMask);

        if (rightFoot.collider || leftFoot.collider) {
            _isJumping = false;
        } else
        {
            _isJumping = true;
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(GroundPoint.position + GroundPointOffset, Vector2.down * RaycastRange);
        Gizmos.DrawRay(GroundPoint.position - GroundPointOffset, Vector2.down * RaycastRange);
    }
}
