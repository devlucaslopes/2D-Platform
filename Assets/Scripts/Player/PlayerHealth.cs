using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    public int TotalHealth { get => health; }

    public void OnHit()
    {
        health--;
        GameManager.Instance.UpdateHealth();

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
