using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Frontline_mage : MonoBehaviour
{
    public bool isActive = false;
    private PlayerHealth PlayerHealth;
    private Damage_Enemy damage_Enemy;
    private Player_Controller player_Controller;    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        damage_Enemy = GetComponent<Damage_Enemy>();
        player_Controller = GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            PlayerHealth.MaxHealth = PlayerHealth.MaxHealth * 2;
            damage_Enemy.Damge = damage_Enemy.Damge * 2;
            player_Controller.movmentSpeed = player_Controller.movmentSpeed * 2;
        }
    }
}
