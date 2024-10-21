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

        if (the_Dryads_Aura.isAlive && !abilityupdate[0])
        {
            UpdateAttackAbUI("Dryads Aura");
            abilityupdate[0] = true;
        }
        if (the_Akashic_Records_script.isAlive && !abilityupdate[1])
        {
            UpdateAttackAbUI("the Akashic Records");
            abilityupdate[1] = true;
        }

    }
    private void UpdateAttackAbUI(string ability)
    {
        abilitiesText.text += ability+ ", ";
    }
}