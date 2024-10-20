using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryads_Aura : MonoBehaviour
{
    public GameObject auraPrefab;
    private GameObject aura;
    public string enemyTag = "Enemy"; // Tag for all enemy objects    
    public int Dryads_Aura_level = 0; // Level of the aura affecting range    
    public bool isAlive = false;
    public bool auraSpawned = false;

    // Scaling factor for different aura levels
    public float[] auraScales = { 1f, 1.5f, 2f, 2.5f, 3f }; // Can adjust this based on level or size needed
    private CircleCollider2D auraCollider;

    void Update()
    {
        if (isAlive)
        {
            initAura();
        }

        // Dynamically resize the aura based on the current level
        if (auraSpawned && aura != null)
        {
            UpdateAuraSize();
        }
    }

    public void initAura()
    {
        if (!auraSpawned)
        {
            Vector3 spawnPos = transform.position;
            aura = Instantiate(auraPrefab, spawnPos, Quaternion.identity);

            // Ensure the aura has a 2D collider and it acts as a trigger
            auraCollider = aura.GetComponent<CircleCollider2D>();
            if (auraCollider == null)
            {
                auraCollider = aura.AddComponent<CircleCollider2D>();
                auraCollider.isTrigger = true;  // Adding 2D trigger collider
            }

            // Set initial circle size based on level
            UpdateAuraSize();

            auraSpawned = true;
        }

        // Keep aura following the player
        if (aura != null)
        {
            Vector3 targetPos = transform.position;
            aura.transform.position = Vector3.MoveTowards(aura.transform.position, targetPos, 5 * Time.deltaTime);
        }
    }

    public void UpdateAuraSize()
    {
        if (aura != null)
        {
            // Scale the aura circle based on the current level
            float scaleFactor = auraScales[Dryads_Aura_level];
            aura.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);  // Apply the same scale for x and y axes

            // Adjust the CircleCollider2D radius to match the scale
            if (auraCollider != null)
            {
                auraCollider.radius = scaleFactor / 2;  // Adjust the radius proportionally to the scale
            }
        }
    }
}
