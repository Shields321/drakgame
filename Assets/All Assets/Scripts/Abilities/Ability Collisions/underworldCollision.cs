using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underworldCollision : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [HideInInspector] public float damage = 5f;
    // This method detects 2D collisions between the book and enemies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // Deal damage to enemy
                Debug.Log("underworld collided with the player and dealt damage!");
            }
        }
    }
}

