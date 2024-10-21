using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public TMP_Text LevelText;
    private UpgradeManager upgradeManager;    
    // Update is called once per frame
    void Update()
    {
        UpdateLevelUI();
    }
    private void UpdateLevelUI()
    {
        GameObject level = GameObject.FindWithTag("GameManager");
        upgradeManager = level.GetComponent<UpgradeManager>();

        LevelText.text = "Level: "+Convert.ToString(upgradeManager.playerLevel);
    }
}
