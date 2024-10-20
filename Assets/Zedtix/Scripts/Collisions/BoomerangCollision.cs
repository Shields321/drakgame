using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangCollision : MonoBehaviour
{
    private Enemy_Health enemyHealth;
    [HideInInspector]public float damage = 5f;
    // This method detects 2D collisions between the book and enemies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent<Enemy_Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);  // Deal damage to enemy
                Debug.Log("Boomerang collided with enemy and dealt damage!");
            }
        }
    }
}
