using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackAbilities : MonoBehaviour
{
    public TMP_Text abilitiesText;
    private GameObject[] abilities;

    private Dryads_Aura the_Dryads_Aura;
    private the_Akashic_Records the_Akashic_Records_script;
    private Beam_of_the_Majin beam_Of_The_Majin;
    private Thorns_of_the_Great_Forest thorns_Of_The_Great_Forest;
    private Dragons_Breath the_Dragons_Breath;
    private Tentacles_of_the_Abyss tentacles_Of_The_Abyss;
    private Magic_Boomerang magic_Boomerang;

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
        GameObject DA = GameObject.FindWithTag("Player");
        the_Dryads_Aura = DA.GetComponent<Dryads_Aura>();
        
        GameObject TAR = GameObject.FindWithTag("Player");
        the_Akashic_Records_script = TAR.GetComponent<the_Akashic_Records>();

        GameObject BOM = GameObject.FindWithTag("Player");
        beam_Of_The_Majin = BOM.GetComponent<Beam_of_the_Majin>();

        GameObject TGF = GameObject.FindWithTag("Player");
        thorns_Of_The_Great_Forest = TGF.GetComponent<Thorns_of_the_Great_Forest>();

        GameObject TDB = GameObject.FindWithTag("Player");
        the_Dragons_Breath = TDB.GetComponent<Dragons_Breath>();

        GameObject TOA = GameObject.FindWithTag("Player");
        tentacles_Of_The_Abyss = TOA.GetComponent<Tentacles_of_the_Abyss>();

        GameObject MB = GameObject.FindWithTag("Player");
        magic_Boomerang = MB.GetComponent<Magic_Boomerang>();

        if (the_Dryads_Aura.isAlive && !abilityupdate[0])
        {
            UpdateAttackAbUI("Dryad's Aura");
            abilityupdate[0] = true;
        }
        if (the_Akashic_Records_script.isAlive && !abilityupdate[1])
        {
            UpdateAttackAbUI("The Akashic Records");
            abilityupdate[1] = true;
        }
        if (beam_Of_The_Majin.isAlive && !abilityupdate[2])
        {
            UpdateAttackAbUI("Beam Of The Majin");
            abilityupdate[2] = true;
        }
        if (thorns_Of_The_Great_Forest.isAlive && !abilityupdate[3])
        {
            UpdateAttackAbUI("Thorns Of The Great Forest");
            abilityupdate[3] = true;
        }
        if (the_Dragons_Breath.isAlive && !abilityupdate[4])
        {
            UpdateAttackAbUI("The Dragon's Breath");
            abilityupdate[4] = true;
        }
        if (tentacles_Of_The_Abyss.isAlive && !abilityupdate[5])
        {
            UpdateAttackAbUI("Tentacles Of The Abyss");
            abilityupdate[5] = true;
        }
        if (magic_Boomerang.isAlive && !abilityupdate[6])
        {
            UpdateAttackAbUI("Magic Boomerang");
            abilityupdate[6] = true;
        }

    }
    private void UpdateAttackAbUI(string ability)
    {
        abilitiesText.text += ability+ ", ";
    }
}