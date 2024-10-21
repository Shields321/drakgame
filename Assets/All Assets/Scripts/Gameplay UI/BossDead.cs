using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    public GameObject Panel;
    public TMP_Text Timer;
    public TMP_Text Kills;
    public TMP_Text TimerText;
    public TMP_Text KillsText;
    private Enemy_Health enemyHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Boss"))
        {
            GameObject exp_Coin = GameObject.FindWithTag("Boss");
            enemyHealth = exp_Coin.GetComponent<Enemy_Health>();
        }
        if (enemyHealth != null)
        {
            if (enemyHealth.healthCheck)
            {

                gameOver();
            }
        }
    
    }

    void gameOver()
    {
        if (Panel != null)
            Panel.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.Pause = true;
        TimerText.text = "Time: " + Timer.text;
        KillsText.text = Kills.text;
        GameManager.Instance.Pause = true;

    }
}
