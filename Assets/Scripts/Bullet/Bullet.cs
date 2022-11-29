using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float Speed;
    [HideInInspector] public float Direction;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(Speed * Direction, 0);
    }
}
