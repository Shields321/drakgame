using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool StopMoveing;
    public bool Pause;
    [Header("Player Stats")]
    public float speed;
    public float Damge;
    public float ExpBoost;
    public TMP_Text TextKill;
    public TMP_Text Abilities_atk;
    public TMP_Text Abilities_def;
    public int NumberOfKills;
    public GameObject Panel;  
    private UpgradeManager UpgradeManager;

    private void Awake()
    {
        if (Instance != null)
        {
            UpgradeManager = GetComponent<UpgradeManager>();
            Debug.LogError("More than one GameManger in scene");
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {        
        if (TextKill!=null)
            TextKill.text = "Kills: " + NumberOfKills.ToString();        
        if (Pause)
        {
            if(Panel!=null)
               Panel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            if (Panel != null)
                Panel.SetActive(false);
            Time.timeScale = 1;

        }

    }
}