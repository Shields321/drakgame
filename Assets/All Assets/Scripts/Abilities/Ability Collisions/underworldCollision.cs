using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderworldCollision : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [HideInInspector] public float damage = 5f;
    private bool isPlayerInZone = false;
    private Circles_of_the_Underworld circles_Of_The_Underworld;

    // This method detects when the player enters the damage zone (trigger collider)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && !isPlayerInZone)
            {
                isPlayerInZone = true;
                StartCoroutine(DamagePlayerOverTime());
            }

        }
    }

    // This method detects when the player exits the damage zone (trigger collider)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false; // Stop dealing damage when the player leaves the zone
        }
    }

    // Coroutine to deal damage every 1.5 seconds while the player is in the zone
    private IEnumerator DamagePlayerOverTime()
    {
        while (isPlayerInZone)
        {
            playerHealth.TakeDamage(damage);  // Deal damage to player
            Debug.Log("Underworld collided with the player and dealt damage!");

            // Wait for 1.5 seconds before dealing damage again
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void finalDelete()
    {
        GameObject CU = GameObject.FindWithTag("Enemy");
        circles_Of_The_Underworld = CU.GetComponent<Circles_of_the_Underworld>();
        circles_Of_The_Underworld.destroyUnderworld();
    }
}
