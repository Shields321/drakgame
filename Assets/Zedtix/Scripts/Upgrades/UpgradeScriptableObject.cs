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
    public enum UpgardeEnum { Apollos_Prophecy, The_Will_of_a_Creator , The_Frontline_mage , The_Demons_Enchantment , SwordSmith_Parry , Semblence_of_polatrity , Kiss_of_life , Elven_Holy_Garments };
    public UpgardeEnum Upgarde ;
    [Range(0,100)]
    public int Chance;
}
