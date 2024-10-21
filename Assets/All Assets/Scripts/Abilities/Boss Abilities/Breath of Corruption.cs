using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath_of_Corruption : MonoBehaviour
{
    public GameObject beamPrefab;
    private GameObject Beam;    
    private bool beamSpawned = false;     
    public bool isAlive = false;
    private float time;
    private float duration = 10;

    // Define the radius within which to spawn beams
    public float spawnRadius = 3.0f; // Adjust this value as needed

    //private float followSpeed = 5f;    

    void Update()
    {
        time += Time.deltaTime;
        if (time >= duration)
        {
            spawnBeam();
            if (time >= duration + 2)
            {
                destroyBeams();
                time = 0f;
            }
        }
    }

    public void spawnBeam()
    {
        if (!beamSpawned)
        {
            // Get player position
            Vector3 BossPos = transform.position;

            // Calculate a random position around the player within the spawn radius
            Vector3 randomOffset = Random.insideUnitCircle * spawnRadius; // Get a random point in a circle
            Vector3 randomSpawnPos = BossPos + randomOffset;

            // Create a beam at the random spawn position
            Beam = Instantiate(beamPrefab, randomSpawnPos, Quaternion.identity);

            // Calculate the direction to move the beam towards
            Vector3 direction = (randomSpawnPos - BossPos).normalized;

            // Calculate the angle based on the direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate angle in degrees

            // Rotate the beam to point in the direction away from the player
            Beam.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            // Set the length of the beam to cover the full distance of the game
            float distanceToEdge = Mathf.Max(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);

            // Adjust the length of the beam based on the direction and distance
            Beam.transform.localScale = new Vector3(1, distanceToEdge, 1); // Assuming the beam is narrow in the x-axis

            // Position the beam correctly
            Vector3 endPoint = randomSpawnPos + direction * distanceToEdge;
            Beam.transform.position = Vector3.Lerp(randomSpawnPos, endPoint, 0.5f); // Set the beam's position to halfway between the random spawn point and the edge

            // Ensure the beam has a 2D collider and it acts as a trigger
            if (Beam.GetComponent<BoxCollider2D>() == null)
            {
                Beam.AddComponent<BoxCollider2D>().isTrigger = true; // Adding 2D trigger collider
            }            
            beamSpawned = true;
        }
    }
    public void destroyBeams()
    {
        
        if (Beam != null)
        {
            Destroy(Beam);
        }
        
        // Reset beam counter
        beamSpawned = false;
        time = 0f; // Reset time after destroying beams
    }
}