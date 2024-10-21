using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circles_of_the_Underworld : MonoBehaviour
{
    public GameObject underworldPrefab;
    private GameObject underworld;
    private TentacleCollision underworldCollision;
    public bool isAlive = false;
    private bool underworldSpawned = false;
    private float spawnRadius = 7f;       
    private float time;    

    void Update()
    {
        // Increment time with each frame
        time += Time.deltaTime;
        // Check if the tentacle should be spawned and destroyed based on time
        if (isAlive)
        {
            if (time <= 3f)
            {
                spawnUnderworld();
            }
            else
            {
                destroyUnderworld();
            }


        }
    }

    // Method to spawn a tentacle at a random position around the player
    public void spawnUnderworld()
    {
        if (!underworldSpawned)
        {
            Vector3 playerPos = transform.position;

            // Generate a random position around the player in 2D (X, Y) and keep Z as 0
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius; // Get a random point in a circle
            Vector3 randomSpawnPos = new Vector3(playerPos.x + randomOffset.x, playerPos.y + randomOffset.y, 0f);

            // Instantiate the tentacle at the calculated random position
            underworld = Instantiate(underworldPrefab, randomSpawnPos, Quaternion.identity);

            // Ensure the tentacle has a 2D collider and it acts as a trigger
            if (underworld.GetComponent<CircleCollider2D>() == null)
            {
                underworld.AddComponent<CircleCollider2D>().isTrigger = true;  // Adding 2D trigger collider
            }            
            underworldSpawned = true;
        }
    }

    // Method to increase damage based on the level    

    // Method to destroy the tentacle after 3 seconds and reset the timer
    public void destroyUnderworld()
    {
        if (underworld != null)
        {
            Destroy(underworld);
            underworld = null;
        }

        underworldSpawned = false;
        time = 0f;  // Reset the timer after destroying the tentacle
    }
}
