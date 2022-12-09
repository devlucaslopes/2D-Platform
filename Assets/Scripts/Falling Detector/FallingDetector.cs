using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDetector : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<PlayerHealth>().OnHit();
            Player.position = Respawn.position;
        }
    }
}
