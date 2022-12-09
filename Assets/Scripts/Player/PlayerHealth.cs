using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    public void OnHit()
    {
        health--;

        Debug.Log($"Vidas: {health}");

        if (health <= 0)
        {
            Debug.Log("GAME OVER!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            OnHit();
        }
    }
}
