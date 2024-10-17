using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Will_of_a_Creator : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private float time;
    private float[] duration = {1f, 3f, 5f };
    public int WOC_level = 0;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {        
        WillOFGod();
    }
    public void WillOFGod()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (isActive && playerHealth.CurrentHealth <= 15)
        {
            
            if (time <= duration[WOC_level])
            {
                playerHealth.willCreate = 0;
                Debug.Log("Invis: " + playerHealth.willCreate);
                    
            }
            else 
            {
                playerHealth.willCreate = 1;
                if (time >= 15)
                {                    
                    time = 0f;
                }                 
            }
                      
        }

    }
}
