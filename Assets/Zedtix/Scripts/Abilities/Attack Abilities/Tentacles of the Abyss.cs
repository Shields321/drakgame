using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacles_of_the_Abyss : MonoBehaviour
{
    public GameObject TentaclePrefab;
    private GameObject Tentacle;
    private TentacleCollision tentacleCollision;
    public bool isAlive = false;
    private bool TentacleSpawned = false;
    private float spawnRadius = 7f;
    public int level = 0;
    private float[] damage_increase = { 0.09f, 0.18f, 0.27f, 0.36f, 0.45f, 0.54f };
    private float time;
    public bool count = false;

    void Update()
    {
        // Increment time with each frame
        time += Time.deltaTime;        
        // Check if the tentacle should be spawned and destroyed based on time
        if (isAlive)
        {
            if (time <= 3f)
            {
                spawnTentacle();                
            }            
            else
            {
                destroyTentacle();
            }
            

        }
    }

    // Method to spawn a tentacle at a random position around the player
    public void spawnTentacle()
    {
        if (!TentacleSpawned)
        {
            Vector3 playerPos = transform.position;

            // Generate a random position around the player in 2D (X, Y) and keep Z as 0
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius; // Get a random point in a circle
            Vector3 randomSpawnPos = new Vector3(playerPos.x + randomOffset.x, playerPos.y + randomOffset.y, 0f);

            // Instantiate the tentacle at the calculated random position
            Tentacle = Instantiate(TentaclePrefab, randomSpawnPos, Quaternion.identity);

            // Ensure the tentacle has a 2D collider and it acts as a trigger
            if (Tentacle.GetComponent<CircleCollider2D>() == null)
            {
                Tentacle.AddComponent<CircleCollider2D>().isTrigger = true;  // Adding 2D trigger collider
            }
            if (level > 0 && count)
            {
                damage_level1();
                count = false;
            }
            TentacleSpawned = true;
        }
    }

    // Method to increase damage based on the level
    public void damage_level1()
    {
        GameObject collision = GameObject.FindWithTag("Tentacle");        
        if (collision != null)
        {            
            tentacleCollision = collision.GetComponent<TentacleCollision>();
            if (tentacleCollision != null)
            {
                Debug.Log(damage_increase[level - 1]);
                // Increase damage according to the level and damage_increase array                
                tentacleCollision.damage += tentacleCollision.damage * damage_increase[level-1];
            }
        }
    }

    // Method to destroy the tentacle after 3 seconds and reset the timer
    public void destroyTentacle()
    {
        if (Tentacle != null)
        {
            Destroy(Tentacle);
            Tentacle = null;
        }

        TentacleSpawned = false;
        time = 0f;  // Reset the timer after destroying the tentacle
    }
}
