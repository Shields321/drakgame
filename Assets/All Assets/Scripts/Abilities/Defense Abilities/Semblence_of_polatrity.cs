using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semblence_of_polatrity : MonoBehaviour
{    
    private Exp_Coin Exp_Coin;    
    public bool isAlive = false;
    // Start is called before the first frame update
    void Start()
    {

        Exp_Coin = GetComponent<Exp_Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Coin"))
        {
            GameObject exp_Coin = GameObject.FindWithTag("Coin");
            Exp_Coin = exp_Coin.GetComponent<Exp_Coin>();
        }        
    }
    public void increaseExpRange()
    {        
        Exp_Coin.Range = Exp_Coin.Range * 2;        
    }

}