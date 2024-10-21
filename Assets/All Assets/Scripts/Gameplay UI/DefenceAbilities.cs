using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefenceAbilities : MonoBehaviour
{
    public TMP_Text abilitiesText;
    private GameObject[] abilities;

    private SwordSmith_Parry swordSmith_Parry;
    private Kiss_of_life kiss_Of_Life;
    private The_Demons_Enchantment the_Demons_Enchantment;
    private The_Will_of_a_Creator the_Will_Of_A_Creator;
    private The_Frontline_mage the_Frontline_mage;
    private Apollos_Prophecy apollos_Prophecy;
    private Elven_Holy_Garments elven_Holy_Garments;
    private Semblence_of_polatrity semblence_Of_Polatrity;

    private bool[] abilityupdate = new bool[]
    {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
    };
    // Start is called before the first frame update        
    // Update is called once per frame
    void Update()
    {
        GameObject SP = GameObject.FindWithTag("Player");
        swordSmith_Parry = SP.GetComponent<SwordSmith_Parry>();

        GameObject KOL = GameObject.FindWithTag("Player");
        kiss_Of_Life = KOL.GetComponent<Kiss_of_life>();

        GameObject TDE = GameObject.FindWithTag("Player");
        the_Demons_Enchantment = TDE.GetComponent<The_Demons_Enchantment>();

        GameObject WOC = GameObject.FindWithTag("Player");
        the_Will_Of_A_Creator = WOC.GetComponent<The_Will_of_a_Creator>();

        GameObject TFM = GameObject.FindWithTag("Player");
        the_Frontline_mage = TFM.GetComponent<The_Frontline_mage>();

        GameObject AP = GameObject.FindWithTag("Player");
        apollos_Prophecy = AP.GetComponent<Apollos_Prophecy>();

        GameObject EHG = GameObject.FindWithTag("Player");
        elven_Holy_Garments = EHG.GetComponent<Elven_Holy_Garments>();

        GameObject SOP = GameObject.FindWithTag("Player");
        semblence_Of_Polatrity = SOP.GetComponent<Semblence_of_polatrity>();


        if (swordSmith_Parry.isAlive && !abilityupdate[0])
        {
            UpdateDefUI("Swordsmith's Parry");
            abilityupdate[0] = true;
        }
        if (kiss_Of_Life.isAlive && !abilityupdate[1])
        {
            UpdateDefUI("Kiss Of Life");
            abilityupdate[1] = true; 
        }
        if (the_Demons_Enchantment.isActive && !abilityupdate[2])
        {
            UpdateDefUI("The Demon's Enchantment");
            abilityupdate[2] = true;
        }
        if (the_Will_Of_A_Creator.isActive && !abilityupdate[3])
        {
            UpdateDefUI("The Will Of A Creator");
            abilityupdate[3] = true;
        }
        if (the_Frontline_mage.isAlive && !abilityupdate[4])
        {
            UpdateDefUI("The Frontline Mage");
            abilityupdate[4] = true;
        }
        if (apollos_Prophecy.isAlive && !abilityupdate[5])
        {
            UpdateDefUI("Apollo's Prophecy");
            abilityupdate[5] = true;
        }
        if (elven_Holy_Garments.isAlive && !abilityupdate[6])
        {
            UpdateDefUI("Elven Holy Garments");
            abilityupdate[6] = true;
        }
        if (semblence_Of_Polatrity.isAlive && !abilityupdate[7])
        {
            UpdateDefUI("Semblence Of Polatrity");
            abilityupdate[7] = true;
        }        

    }
    private void UpdateDefUI(string ability)
    {
        abilitiesText.text += ability + ", ";
    }
}
