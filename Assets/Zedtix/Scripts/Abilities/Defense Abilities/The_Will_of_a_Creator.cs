using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Will_of_a_Creator : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Damge_Player Damge_Player;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        Damge_Player = GetComponent<Damge_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive & playerHealth.CurrentHealth <= 15)
        {
            Damge_Player.Damge = 0;
        }
        else
        {
            Damge_Player.Damge = 5;
        }
    }
}
