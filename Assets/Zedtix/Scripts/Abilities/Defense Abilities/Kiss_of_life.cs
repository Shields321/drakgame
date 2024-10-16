using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiss_of_life : MonoBehaviour
{
    private Damage_Enemy Damage_Enemy;
    private PlayerHealth PlayerHealth;
    private upgradeManager upgradeManager;
    private float[] healAmount = { 0.1f, 0.2f, 0.3f };
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        Damage_Enemy = GetComponent<Damage_Enemy>();
        PlayerHealth = GetComponent<PlayerHealth>();
        upgradeManager = GetComponent<upgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive & Damage_Enemy.enemyHit)
        {
            PlayerHealth.CurrentHealth += healAmount[upgradeManager.Kiss_of_life_level - 1];
        }
    }
}
