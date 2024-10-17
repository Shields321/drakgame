using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instace;

    [SerializeField] private float MaxExp = 50;
    [SerializeField] private float CurrentExp;
    [SerializeField] private Slider ExpBar;
    [SerializeField] private GameObject PlayerObject;
    private float hpPerLevel=1.5f;

    public List<UpgradeScriptableObject> UpgadeToSpawn;
    public List<GameObject> UpgadeUiObject;
    [SerializeField] private GameObject UpgradeObject;
    private List<UpgradeScriptableObject> spawnedUpgades = new List<UpgradeScriptableObject>();
    public bool GenerateUpgrade;

    private SwordSmith_Parry swordSmith_Parry;
    private Kiss_of_life kiss_Of_Life;
    public The_Demons_Enchantment the_Demons_Enchantment;
    public The_Will_of_a_Creator the_Will_Of_A_Creator;
    private void Awake()
    {
        Instace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ExpBar.maxValue = MaxExp;
        if (UpgadeUiObject.Count < 3)
        {
            Debug.LogError("There are not enough Upgade Ui Object.");
            return;

        }
        else if (UpgadeToSpawn.Count < 3)
        {
            Debug.LogError("There are not enough objects to spawn.");
            return;
        }
    }

    private void Update()
    {
        ExpBar.value = CurrentExp;
        int objectsToSpawnCount = UpgadeToSpawn.Count;

        if (CurrentExp >= MaxExp)
        {
            CurrentExp = 0;
            GenerateUpgrade = true;
            MenuButtonController.Instance.CurntButton = UpgradeObject.transform.GetChild(0).gameObject;

            MaxExp *= hpPerLevel;
            SetMaxExp(MaxExp);

        }

        if (spawnedUpgades.Count < 3 && GenerateUpgrade == true)
        {
            UpgradeObject.SetActive(true);
            GameManager.Instance.Pause = true;
            Generate();
        }
        if (spawnedUpgades.Count >= 3)
        {
            GenerateUpgrade = false;
            spawnedUpgades.Clear();
        }
    }
    void Generate()
    {

        int totalSpawnChance = 0;

        // Calculate the total spawn chance for all objects
        foreach (UpgradeScriptableObject spawnInfo in UpgadeToSpawn)
        {
            totalSpawnChance += spawnInfo.Chance;
        }

        // Generate a random value within the total spawn chance
        int randomValue = Random.Range(0, totalSpawnChance);

        // Determine which object should be spawned
        foreach (UpgradeScriptableObject spawnInfo in UpgadeToSpawn)
        {
            if (randomValue < spawnInfo.Chance)
            {
                UpgradeScriptableObject objectToSpawn = spawnInfo;

                // Check if the object has not been spawned before
                if (!spawnedUpgades.Contains(objectToSpawn))
                {
                    Debug.Log(objectToSpawn);
                    UpgadeUiObject[spawnedUpgades.Count].GetComponent<UpgradeUi>().Upgrade = objectToSpawn;
                    Debug.Log("Upgade" + objectToSpawn.Title);
                    spawnedUpgades.Add(objectToSpawn);
                    break;
                }
            }
            else
            {
                randomValue -= spawnInfo.Chance;
            }
        }
    }
    public void Close()
    {
        GameManager.Instance.Pause = false;
        AudioManager.instance.PlaySound("Upgrade");
        UpgradeObject.SetActive(false);
    }
    public void SetMaxExp(float Exp)
    {
        ExpBar.maxValue = MaxExp;
        ExpBar.value = 0;
    }
    public void AddExp(float Exp)
    {
        CurrentExp += Exp;
    }
    public void The_Demons_Enchantment()
    {
        GameObject TDE = GameObject.FindWithTag("Player");
        the_Demons_Enchantment = TDE.GetComponent<The_Demons_Enchantment>();
        the_Demons_Enchantment.damageIncrease();

        the_Demons_Enchantment.isActive = true;
        if (the_Demons_Enchantment.The_Demons_Enchantment_level <= 3)
            the_Demons_Enchantment.The_Demons_Enchantment_level++;
    }
    public void SwordSmith_Parry()
    {
        GameObject parry = GameObject.FindWithTag("Player");
        swordSmith_Parry = parry.GetComponent<SwordSmith_Parry>();
        swordSmith_Parry.Deflect();

        swordSmith_Parry.isActive = true;
        if (swordSmith_Parry.SwordSmith_Parry_level <= 6)
            swordSmith_Parry.SwordSmith_Parry_level++;
    }
    public void Kiss_of_life()
    {
        GameObject kiss = GameObject.FindWithTag("Player");
        kiss_Of_Life = kiss.GetComponent<Kiss_of_life>();
        kiss_Of_Life.start_kissing();

        kiss_Of_Life.isActive = true;
        if (kiss_Of_Life.Kiss_of_life_level <= 3)
            kiss_Of_Life.Kiss_of_life_level++;
    }
    public void Elven_Holy_Garments()
    {
        PlayerObject.GetComponent<Elven_Holy_Garments>().updateDef();
    }
    public void The_Will_of_a_Creator()
    {
        GameObject WOC = GameObject.FindWithTag("Player");
        the_Will_Of_A_Creator = WOC.GetComponent<The_Will_of_a_Creator>();

        the_Will_Of_A_Creator.isActive = true;
        if (the_Will_Of_A_Creator.WOC_level <= 3)
            the_Will_Of_A_Creator.WOC_level++;
        PlayerObject.GetComponent<The_Will_of_a_Creator>().WillOFGod();
    }
    public void Apollos_Prophecy()
    {        
        PlayerObject.GetComponent<Apollos_Prophecy>().increaseExpGain();
    }
    public void The_Frontline_mage()
    {
        PlayerObject.GetComponent<The_Frontline_mage>().doubleStats();
    }
}
