using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    private bool _isAlive = true;

    public int TotalHealth { get => health; }
    public bool IsAlive { get => _isAlive; }

    public void OnHit()
    {
        health--;
        GameManager.Instance.UpdateHealth();

        if (health <= 0)
        {
            _isAlive = false;
            GameManager.Instance.ShowGameOver();
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
