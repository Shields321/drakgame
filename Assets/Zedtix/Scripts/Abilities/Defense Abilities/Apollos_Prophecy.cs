using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apollos_Prophecy : MonoBehaviour
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
        if (isAlive)
        {
            Exp_Coin.Exp = Exp_Coin.Exp + (Exp_Coin.Exp*0.3);
        }
    }
}
