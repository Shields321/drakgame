using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Demons_Enchantment : MonoBehaviour
{
    public Transform enemyTransform;    
    public GameObject enemyPrefab;
    private Damage_Enemy damage_Enemy;
    private upgradeManager upgradeManager;
    public Transform playerTransform;
    public bool isActive = false;
    public float range;
    private float[] dmg = { 1.2f, 1.4f, 1.6f };        
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = transform;   
        upgradeManager = new upgradeManager();
        damage_Enemy = new Damage_Enemy();
    }

    // Update is called once per frame
    void Update()
    {        
        float distance = Vector3.Distance(enemyTransform.position, playerTransform.transform.position);
        if (distance < range & isActive)
        {
            damage_Enemy.dmgIncrease = dmg[upgradeManager.The_Demons_Enchantment_level - 1];
        }        
    }    
}
