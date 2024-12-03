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
    public bool victorySFX;
    private Enemy_Health enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        victorySFX = false;
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

                if (victorySFX == false)
                {
                    AudioManagerTwo.instance.PlayFloorClearedSFX();
                    victorySFX = true;
                }
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
