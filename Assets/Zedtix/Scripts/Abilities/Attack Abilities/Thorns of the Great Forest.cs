using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns_of_the_Great_Forest : MonoBehaviour
{    
    private PlayerHealth PlayerHealth;
    private Enemy_Health EnemyHealth;        
    public bool isAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerHealth = player.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            throns();
        }
    }
    public void throns()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        EnemyHealth = enemy.GetComponent<Enemy_Health>();

        if (PlayerHealth.isTakeDamage)
        {
            EnemyHealth.TakeDamage(PlayerHealth.finalDamage * 0.02f);
            PlayerHealth.isTakeDamage = false;
        }
    }
}
