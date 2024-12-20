using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeUi : MonoBehaviour
{
    private UpgradeUi upgradeUi;
    public UpgradeScriptableObject Upgrade;

    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private TMP_Text Lore;
    [SerializeField] private Image Icon;
    [SerializeField] private string UpgradeName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Title.text = Upgrade.Title;
        Description.text = Upgrade.Description;
        Lore.text = Upgrade.Lore;
        //Icon.sprite = Upgrade.Icon;
        UpgradeName = Upgrade.name;

    }
  public void UpgradeFunction()
    {        
        UpgradeManager.Instace.Invoke(Upgrade.Upgarde.ToString(),0);

    }
}
