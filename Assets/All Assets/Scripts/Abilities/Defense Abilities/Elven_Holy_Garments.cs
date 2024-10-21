using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elven_Holy_Garments : MonoBehaviour
{
    private PlayerHealth PlayerHealth;  
    public bool isAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerHealth = GameObject.FindWithTag("Player");
        PlayerHealth = playerHealth.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void updateDef()
    {
        PlayerHealth.def = 0.5f;
    }
}
