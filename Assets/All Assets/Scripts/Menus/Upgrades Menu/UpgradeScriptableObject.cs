using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewUpgrade", menuName = "UpgradeObject")]

public class UpgradeScriptableObject : ScriptableObject
{

    //public Sprite Icon;
    public string Title;
    public string Description;
    public enum UpgardeEnum { Apollos_Prophecy, The_Will_of_a_Creator , The_Frontline_mage , The_Demons_Enchantment , SwordSmith_Parry , Semblence_of_polatrity , Kiss_of_life , Elven_Holy_Garments,//def abilities
                              Beam_of_the_Majin, Dragons_Breath, Dryads_Aura, Magic_Boomerang, Magic_Homunculus, Tentacles_of_the_Abyss, the_Akashic_Records, Thorns_of_the_Great_Forest //Atk abilities
    };
    public UpgardeEnum Upgarde ;
    [Range(0,100)]
    public int Chance;
}
