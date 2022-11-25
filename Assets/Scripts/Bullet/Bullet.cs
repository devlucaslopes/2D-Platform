using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.velocity = Vector2.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
