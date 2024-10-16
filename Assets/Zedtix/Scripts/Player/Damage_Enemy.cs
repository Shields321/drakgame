using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Enemy : MonoBehaviour
{

    [SerializeField] public float Damge = 5;
    private float StartWaitTime = 0.05f;
    private float WaitTime;
    public float dmgIncrease=1;
    public bool enemyHit = false;

    void Start()
    {
        WaitTime = StartWaitTime;       
    }

    void Update()
    {
        WaitTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && WaitTime <= 0)
        {
            enemyHit = true;
            collision.GetComponent<Enemy_Health>().TakeDamage(Damge * dmgIncrease);
            WaitTime = StartWaitTime;
        }
    }
}
