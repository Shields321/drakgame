using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_of_the_Majin : MonoBehaviour
{
    public GameObject beamPrefab;
    private GameObject Beam;
    private bool beamSpawned = false;

    public int Level = 0;
    public bool isAlive = false;
    private float time;

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        if (isAlive && time <= 1)
        {
            spawnBeam();
        }
        else
        {
            destroyBeam();
        }
    }

    public void spawnBeam()
    {
        if (!beamSpawned)
        {
            // Get mouse position in world space
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0; // Ensure z-coordinate is 0 for 2D

            // Get player position
            Vector3 playerPos = transform.position;

            // Calculate the direction from player to mouse
            Vector3 direction = (mousePos - playerPos).normalized;

            // Create a beam at the player's position
            Beam = Instantiate(beamPrefab, playerPos, Quaternion.identity);

            // Calculate the angle based on the direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate angle in degrees

            // Rotate the beam to point towards the mouse
            Beam.transform.rotation = Quaternion.Euler(0, 0, angle-90);

            // Set the length of the beam to cover the full distance of the game
            float distanceToEdge = Mathf.Max(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);

            // Adjust the length of the beam based on the direction and distance
            Beam.transform.localScale = new Vector3(1, distanceToEdge, 1); // Assuming the beam is narrow in the x-axis

            // Position the beam correctly
            Vector3 endPoint = playerPos + direction * distanceToEdge;
            Beam.transform.position = Vector3.Lerp(playerPos, endPoint, 0.5f); // Set the beam's position to halfway between the player and the edge

            // Ensure the beam has a 2D collider and it acts as a trigger
            if (Beam.GetComponent<BoxCollider2D>() == null)
            {
                Beam.AddComponent<BoxCollider2D>().isTrigger = true; // Adding 2D trigger collider
            }

            beamSpawned = true;
        }
    }

    public void destroyBeam()
    {
        if (Beam != null)
        {
            Destroy(Beam);
        }
        beamSpawned = false;
        time = 0f;
    }
}
