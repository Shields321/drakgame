using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class the_Akashic_Records : MonoBehaviour
{
    public GameObject BooksPrefab;
    private GameObject Books;
    private Enemy_Health Enemy_Health;
    private BookCollision bookCollision;
    private GameObject[] spawnedBooks = new GameObject[3];
    public bool isAlive = false;
    public int the_Akashic_Records_level = 0;
    private float[] damage_increase = { 0.04f, 0.08f, 0.12f, 0.16f, 0.2f, 0.24f };
    private int bookAmounts = 0;  // Start from 0
    private bool bookSpawned = false;

    // Array of different offsets for each book
    private Vector3[] offsets = new Vector3[]
    {
        new Vector3(2f, 2f, 0f),   // Offset for book 1
        new Vector3(-2f, 2f, 0f),  // Offset for book 2
        new Vector3(0f, -2f, 0f)   // Offset for book 3
    };

    private Vector3 playerPos;

    private float rotationSpeed = 6f;
    private float angle = 0f;
    private float radius = 2f;

    void Update()
    {
        if (isAlive)
        {
            FollowPlayer();
            RotateBooks();
        }
    }

    // Follow player with smooth movement and maintain distance
    private void FollowPlayer()
    {
        // Spawn books only if they have not been spawned yet and the level matches
        if (!bookSpawned && (the_Akashic_Records_level == 1 || the_Akashic_Records_level == 3 || the_Akashic_Records_level == 6))
        {
            bookAmounts++;
            playerPos = transform.position;            
            for (int i = 0; i < bookAmounts; i++)  // Iterate through all 3 books
            {
                Vector3 spawnPos = playerPos + offsets[i];  // Use different offset for each book
                spawnedBooks[i] = Instantiate(BooksPrefab, spawnPos, Quaternion.identity);

                // Ensure the book has a 2D collider and it acts as a trigger
                if (spawnedBooks[i].GetComponent<BoxCollider2D>() == null)
                {
                    spawnedBooks[i].AddComponent<BoxCollider2D>().isTrigger = true;  // Adding 2D trigger collider
                }
            }            
            bookSpawned = true; // All books have been spawned
        }

        // Update position of spawned books to follow the player
        for (int i = 0; i < bookAmounts; i++)
        {
            if (spawnedBooks[i] != null)
            {
                Vector3 targetPos = transform.position + offsets[i];  // Each book maintains its unique offset
                spawnedBooks[i].transform.position = Vector3.MoveTowards(spawnedBooks[i].transform.position, targetPos, 5 * Time.deltaTime);
            }
        }
    }

    // Rotates the books around the player
    private void RotateBooks()
    {
        angle += rotationSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        playerPos = transform.position;
        for (int i = 0; i < bookAmounts; i++)
        {
            if (spawnedBooks[i] != null)
            {
                // Circular rotation around the player with the same radius
                spawnedBooks[i].transform.position = new Vector3(playerPos.x + x, playerPos.y + y, 0);
            }
        }
    }

    // Increase damage based on level
    public void damage_level()
    {
        GameObject collision = GameObject.FindWithTag("Books");
        if (collision != null)
        {
            bookCollision = collision.GetComponent<BookCollision>();
            if (bookCollision != null)
            {
                bookCollision.damage += bookCollision.damage * damage_increase[the_Akashic_Records_level];
            }
        }
    }
}
