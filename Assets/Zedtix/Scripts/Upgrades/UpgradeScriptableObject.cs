using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewUpgrade", menuName = "UpgradeObject")]

public class UpgradeScriptableObject : ScriptableObject
{
    
    public string Title;    
    public enum UpgradeEnum {AddHealth, Heal, AddSpeed, AddDamge, NewOrb , AttackSpeed , ShootProjectile };
    public UpgradeEnum Upgrade;
    [Range(0,100)]
    public int Chance;

}
