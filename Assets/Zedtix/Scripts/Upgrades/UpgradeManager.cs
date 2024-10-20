using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private The_Demons_Enchantment the_Demons_Enchantment;
    private The_Will_of_a_Creator the_Will_Of_A_Creator;
    private Dryads_Aura the_Dryads_Aura;
    private the_Akashic_Records the_Akashic_Records_script;
    private Beam_of_the_Majin beam_Of_The_Majin;
    private Thorns_of_the_Great_Forest thorns_Of_The_Great_Forest;
    private Dragons_Breath the_Dragons_Breath;
    private Tentacles_of_the_Abyss tentacles_Of_The_Abyss;
    private Magic_Boomerang magic_Boomerang;
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

    //defence abilities
    public void The_Demons_Enchantment()
    {
        GameObject TDE = GameObject.FindWithTag("Player");
        the_Demons_Enchantment = TDE.GetComponent<The_Demons_Enchantment>();
        the_Demons_Enchantment.damageIncrease();

        the_Demons_Enchantment.isActive = true;
        if (the_Demons_Enchantment.The_Demons_Enchantment_level < 3)
            the_Demons_Enchantment.The_Demons_Enchantment_level++;
    }
    public void SwordSmith_Parry()
    {
        GameObject parry = GameObject.FindWithTag("Player");
        swordSmith_Parry = parry.GetComponent<SwordSmith_Parry>();
        swordSmith_Parry.Deflect();

        swordSmith_Parry.isActive = true;
        if (swordSmith_Parry.SwordSmith_Parry_level < 6)
            swordSmith_Parry.SwordSmith_Parry_level++;
    }
    public void Kiss_of_life()
    {
        GameObject kiss = GameObject.FindWithTag("Player");
        kiss_Of_Life = kiss.GetComponent<Kiss_of_life>();
        kiss_Of_Life.start_kissing();

        kiss_Of_Life.isActive = true;
        if (kiss_Of_Life.Kiss_of_life_level < 3)
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
        if (the_Will_Of_A_Creator.WOC_level < 3)
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
    public void Semblence_of_polatrity()
    {
        PlayerObject.GetComponent<Semblence_of_polatrity>().increaseExpRange();
    }
    //Attack abilities
    public void Beam_of_the_Majin()
    {
        GameObject BOM = GameObject.FindWithTag("Player");
        beam_Of_The_Majin = BOM.GetComponent<Beam_of_the_Majin>();
        beam_Of_The_Majin.isAlive = true;
        if (beam_Of_The_Majin.Level < 6)
        {
            beam_Of_The_Majin.Level++;
        }
        PlayerObject.GetComponent<Beam_of_the_Majin>().spawnBeam();
    }
    public void Dragons_Breath()
    {
        GameObject DB = GameObject.FindWithTag("Player");
        the_Dragons_Breath = DB.GetComponent<Dragons_Breath>();
        the_Dragons_Breath.isAlive = true;
        if(the_Dragons_Breath.Level < 3)
        {
            the_Dragons_Breath.Level++;
        }
        PlayerObject.GetComponent<Dragons_Breath>().spawnBeam();
    }
    public void Dryads_Aura()
    {
        GameObject DA = GameObject.FindWithTag("Player");
        the_Dryads_Aura = DA.GetComponent<Dryads_Aura>();

        the_Dryads_Aura.isAlive = true;
        if (the_Dryads_Aura.Dryads_Aura_level <= 6)
            the_Dryads_Aura.Dryads_Aura_level++;
        PlayerObject.GetComponent<Dryads_Aura>().initAura();
    }
    public void Magic_Boomerang()
    {
        GameObject MB = GameObject.FindWithTag("Player");
        magic_Boomerang = MB.GetComponent<Magic_Boomerang>();
        magic_Boomerang.isAlive = true;
        if(magic_Boomerang.level < 6)
        {
            magic_Boomerang.level++;
        }
        PlayerObject.GetComponent<Magic_Boomerang>().throwBoomerang();
        magic_Boomerang.count = true;
    }    
    public void Tentacles_of_the_Abyss()
    {
        GameObject TA = GameObject.FindWithTag("Player");
        tentacles_Of_The_Abyss = TA.GetComponent<Tentacles_of_the_Abyss>();
        tentacles_Of_The_Abyss.isAlive = true;
        if (tentacles_Of_The_Abyss.level < 6)
            tentacles_Of_The_Abyss.level++;
        PlayerObject.GetComponent<Tentacles_of_the_Abyss>().spawnTentacle();
        tentacles_Of_The_Abyss.count = true;
    }
    public void the_Akashic_Records()
    {
        GameObject TAR = GameObject.FindWithTag("Player");
        the_Akashic_Records_script = TAR.GetComponent<the_Akashic_Records>();
        the_Akashic_Records_script.isAlive = true;        
        if (the_Akashic_Records_script.the_Akashic_Records_level<6)
            the_Akashic_Records_script.the_Akashic_Records_level++;
        PlayerObject.GetComponent<the_Akashic_Records>().damage_level();
    }
    public void Thorns_of_the_Great_Forest()
    {
        GameObject TGF = GameObject.FindWithTag("Player");
        thorns_Of_The_Great_Forest = TGF.GetComponent<Thorns_of_the_Great_Forest>();
        thorns_Of_The_Great_Forest.isAlive = true;
        PlayerObject.GetComponent<Thorns_of_the_Great_Forest>().throns();


    }
}
