using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Demons_Enchantment : MonoBehaviour
{        
    public GameObject enemyPrefab;    
    private Enemy_Health damage_Enemy;
    private UpgradeManager upgradeManager;
    public Transform playerTransform;
    public int The_Demons_Enchantment_level = 0;
    public bool isActive = false;
    public float range;
    private float[] dmg = { 1.2f, 1.4f, 1.6f };        
    // Start is called before the first frame update
    void Start()
    {           
        upgradeManager = FindObjectOfType<UpgradeManager>();
        damage_Enemy = enemyPrefab.GetComponent<Enemy_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            GameObject isDamage = GameObject.FindWithTag("Enemy");
            damage_Enemy = isDamage.GetComponent<Enemy_Health>();
            damageIncrease();
        }        
    }   
    public void damageIncrease()
    {
        float distance = Vector3.Distance(enemyPrefab.transform.position, playerTransform.transform.position);
        if (distance > range & isActive)
        {            
            damage_Enemy.dmgIncrease = dmg[The_Demons_Enchantment_level - 1];            
        }
    }
}
