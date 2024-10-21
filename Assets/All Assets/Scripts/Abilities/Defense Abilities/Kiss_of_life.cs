using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiss_of_life : MonoBehaviour
{
    private Enemy_Health enemy_Health;
    private PlayerHealth PlayerHealth;    
    private float[] healAmount = { 0.3f, 0.6f, 0.9f };
    public int Kiss_of_life_level = 0;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {        
        GameObject heal = GameObject.FindWithTag("Player");
        PlayerHealth = heal.GetComponent<PlayerHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            GameObject isDamage = GameObject.FindWithTag("Enemy");
            enemy_Health = isDamage.GetComponent<Enemy_Health>();
            start_kissing();
        }
    }
    public void start_kissing()
    {
        if (isActive & enemy_Health.isHitEnemy & PlayerHealth.CurrentHealth < PlayerHealth.MaxHealth)
        {            
            PlayerHealth.CurrentHealth = PlayerHealth.CurrentHealth + healAmount[Kiss_of_life_level-1];   
            enemy_Health.isHitEnemy = false;
        }
    }
}
