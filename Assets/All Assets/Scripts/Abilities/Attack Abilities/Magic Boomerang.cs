using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Boomerang : MonoBehaviour
{
    public GameObject boomerangPrefab;
    private GameObject boomerang;
    private BoomerangCollision BoomerangCollision;
    public bool isAlive = false;
    public int level = 0;
    private bool boomerangSpawned = false;
    public float targetedRadius = 10f;
    private float time;
    private Vector3 targetPosition;
    private float[] damage_increase = {5,6,7,8,9,10};
    public bool count = false;
    // Speed at which the boomerang moves
    public float boomerangSpeed = 5f;
    
    // Duration before the boomerang returns
    public float boomerangReturnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;        
        if (isAlive && !boomerangSpawned)
        {
            throwBoomerang();
        }

        if (boomerangSpawned && boomerang != null)
        {
            MoveBoomerang();

            // Check if enough time has passed to delete the boomerang
            if (time >= boomerangReturnTime)
            {
                deleteBoomerang();
            }
        }        
    }

    // Spawns the boomerang and sets its target position
    public void throwBoomerang()
    {
        if (!boomerangSpawned)
        {
            boomerang = Instantiate(boomerangPrefab, transform.position, Quaternion.identity);

            // Calculate a random point around the player within the targeted radius
            Vector2 randomOffset = Random.insideUnitCircle * targetedRadius;
            targetPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

            // Add collider if not present
            if (boomerang.GetComponent<BoxCollider2D>() == null)
            {
                boomerang.AddComponent<BoxCollider2D>().isTrigger = true; // Adding 2D trigger collider
            }
            if (level > 0 && count)
            {
                damage_level();
                count = false;
            }
            boomerangSpawned = true;
        }
    }

    // Moves the boomerang toward the target position
    private void MoveBoomerang()
    {
        if (boomerang != null)
        {
            boomerang.transform.position = Vector3.MoveTowards(boomerang.transform.position, targetPosition, boomerangSpeed * Time.deltaTime);

            // Check if boomerang has reached its target position
            if (Vector3.Distance(boomerang.transform.position, targetPosition) < 0.1f)
            {                
                targetPosition = transform.position; // Set the target back to player position
            }
        }
    }
    public void damage_level()
    {
        GameObject collision = GameObject.FindWithTag("Boomerang");
        if (collision != null)
        {
            BoomerangCollision = collision.GetComponent<BoomerangCollision>();
            if (BoomerangCollision != null)
            {
                BoomerangCollision.damage += damage_increase[level-1];
            }
        }
    }
    // Deletes the boomerang and resets the state
    public void deleteBoomerang()
    {
        if (boomerang != null)
        {
            Destroy(boomerang);
            boomerang = null;
        }

        boomerangSpawned = false;
        time = 0f;
    }
}
