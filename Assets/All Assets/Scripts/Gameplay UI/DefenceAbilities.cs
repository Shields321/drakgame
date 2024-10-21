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

    private bool[] abilityupdate = new bool[]
    {
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

        if (swordSmith_Parry.isAlive && !abilityupdate[0])
        {
            UpdateAttackAbUI("swordSmith Parry");
            abilityupdate[0] = true;
        }
        if (kiss_Of_Life.isAlive && !abilityupdate[1])
        {
            UpdateAttackAbUI("kiss Of Life");
            abilityupdate[1] = true;
        }

    }
    private void UpdateAttackAbUI(string ability)
    {
        abilitiesText.text += ability + ", ";
    }
}
