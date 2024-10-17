using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apollos_Prophecy : MonoBehaviour
{    
    private Exp_Coin Exp_Coin;
    private GameObject exp_coin;    
    // Start is called before the first frame update    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Coin"))
        {
            GameObject exp_Coin = GameObject.FindWithTag("Coin");
            Exp_Coin = exp_Coin.GetComponent<Exp_Coin>();
        }
    }    
    public void increaseExpGain()
    {
        Exp_Coin.Exp += (Exp_Coin.Exp * 0.2f);
        Debug.Log(Exp_Coin.Exp);
    }
}
