using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public abstract class abilitiesManager : MonoBehaviour
{
    Elven_Holy_Garments Elven_Holy_Garments;
    Semblence_of_polatrity semblence_Of_Polatrity;
    Apollos_Prophecy Apollos_Prophecy;
    The_Frontline_mage the_Frontline_Mage;
    The_Demons_Enchantment the_Demons_Enchantment;
    SwordSmith_Parry SwordSmith_Parry;
    The_Will_of_a_Creator the_Will_Of_A_Creator;
    Kiss_of_life kiss_Of_Life;
    private Dictionary<string, float> abilityCooldown = new Dictionary<string, float>();
    private float[] timer;    
    void Start()
    {
        Elven_Holy_Garments = GetComponent<Elven_Holy_Garments>();
        semblence_Of_Polatrity = GetComponent<Semblence_of_polatrity>();
        Apollos_Prophecy = GetComponent<Apollos_Prophecy>();
        the_Frontline_Mage = GetComponent<The_Frontline_mage>();
        the_Demons_Enchantment = GetComponent<The_Demons_Enchantment>();
        SwordSmith_Parry = GetComponent<SwordSmith_Parry>();
        the_Will_Of_A_Creator = GetComponent<The_Will_of_a_Creator>();
        kiss_Of_Life = GetComponent<Kiss_of_life>();
    }
    void Update()
    {
        timer[0] += Time.deltaTime;
        if (timer[0] >= abilityCooldown["EHG"])
        {
            exeEHG();
            timer[0] = 0f;
        }
        timer[1] += Time.deltaTime;
        if (timer[1] >= abilityCooldown["SOP"])
        {
            exeSOP();
            timer[1] = 0f;
        }
        timer[2] += Time.deltaTime;
        if (timer[2] >= abilityCooldown["AP"])
        {
            exeAP();
            timer[2] = 0f;
        }
        timer[3] += Time.deltaTime;
        if (timer[3] >= abilityCooldown["TFM"])
        {
            exeTFM();
            timer[3] = 0f;
        }
        timer[4] += Time.deltaTime;
        if (timer[4] >= abilityCooldown["TDE"])
        {
            exeTDE();
            timer[4] = 0f;
        }
        timer[5] += Time.deltaTime;
        if (timer[5] >= abilityCooldown["SSP"])
        {
            exeSSP();
            timer[5] = 0f;
        }
        timer[6] += Time.deltaTime;
        if (timer[6] >= abilityCooldown["TWC"])
        {
            exeTWC();
            timer[6] = 0f;
        }
        timer[7] += Time.deltaTime;
        if (timer[7] >= abilityCooldown["KOL"])
        {
            exeKOL();
            timer[7] = 0f;
        }
    }
    private void setCooldowns()
    {
        //Change the cooldowns
        abilityCooldown["EHG"] = 2f;
        abilityCooldown["SOP"] = 2f;
        abilityCooldown["AP"] = 2f;
        abilityCooldown["TFM"] = 2f;
        abilityCooldown["TDE"] = 2f;
        abilityCooldown["SSP"] = 2f;
        abilityCooldown["TWC"] = 2f;
        abilityCooldown["KOL"] = 2f;
    }   
    public void exeEHG()
    {
        Elven_Holy_Garments.isAlive = true;
    }
    public void exeSOP()
    {
        Elven_Holy_Garments.isAlive = true;
    }
    public void exeAP()
    {
        Apollos_Prophecy.isAlive = true;
    }
    public void exeTFM()
    {
        the_Frontline_Mage.isActive = true;
    }
    public void exeTDE()
    {
        the_Demons_Enchantment.isActive = true;
    }
    public void exeSSP()
    {
        SwordSmith_Parry.isActive = true;
    }
    public void exeTWC()
    {
        the_Will_Of_A_Creator.isActive = true;
    }
    public void exeKOL()
    {
        kiss_Of_Life.isActive = true;
    }
}*/
