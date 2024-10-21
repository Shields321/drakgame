using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SwordSmith_Parry : MonoBehaviour
{
    private UpgradeManager upgradeManager;
    private PlayerHealth Damge_Player;
    private int[] chance = {5,10,15,20,25,30 };
    public int SwordSmith_Parry_level = 0;
    public bool isAlive = false;
    private float time = 3f;
    private float timeab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject updateManager = GameObject.FindWithTag("Player");        
        upgradeManager = updateManager.GetComponent<UpgradeManager>();
        GameObject dmg = GameObject.FindWithTag("Player");
        Damge_Player = dmg.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        timeab += Time.deltaTime;
        if (time < timeab) {
            Deflect();            
            timeab = 0f;
        }
    }
    public void Deflect()
    {
        if (isAlive)
        {
            float value = UnityEngine.Random.Range(0, 100);
            if (value <= chance[SwordSmith_Parry_level - 1])
            {
                Damge_Player.parry = 0;                
            }  
            else
            {
                Damge_Player.parry = 1;
            }
        }        
    }
}
