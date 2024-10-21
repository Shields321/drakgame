using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Frontline_mage : MonoBehaviour
{    
    private PlayerHealth PlayerHealth;    
    private Player_Controller player_Controller;
    public bool isAlive = false;
    // Start is called before the first frame update
    void Start()
    {                
        GameObject playerhp = GameObject.FindWithTag("Player");        
        GameObject playerc = GameObject.FindWithTag("Player");
                
        PlayerHealth = playerhp.GetComponent<PlayerHealth>();        
        player_Controller = playerc.GetComponent<Player_Controller>();        
    }    
    public void doubleStats()
    {
        
        PlayerHealth.MaxHealth = PlayerHealth.MaxHealth * 2;
        player_Controller.movmentSpeed = player_Controller.movmentSpeed * 2;               
        
    }
}
