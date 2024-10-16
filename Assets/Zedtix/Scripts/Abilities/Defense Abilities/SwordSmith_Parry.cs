using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SwordSmith_Parry : MonoBehaviour
{
    private upgradeManager upgradeManager;
    private Damge_Player Damge_Player;
    private int[] chance = {5,10,15,20,25,30 };
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = GetComponent<upgradeManager>();
        Damge_Player = GetComponent<Damge_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float value = UnityEngine.Random.Range(0,100);
        if (value <= chance[upgradeManager.SwordSmith_Parry_level - 1])
        {
            Damge_Player.Damge = 0;
        }
        else 
        {
            Damge_Player.Damge = 5;
        }
    }
}
