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
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
            PlayerHealth.def = 15f;
    }
}
