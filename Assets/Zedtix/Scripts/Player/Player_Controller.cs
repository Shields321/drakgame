using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float movmentSpeed = 5f;

    private Rigidbody2D rb;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                moveY = +1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1); // or activate look right some other way
                moveX = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1); // activate looking left
                moveX = +1f;
            }

            moveDir = new Vector3(moveX, moveY).normalized;
            if (moveX != 0 || moveY != 0)
            {
                // Not idle
                lastMoveDir = moveDir;
            }
      
    }

    private void FixedUpdate()
    {

        rb.velocity = moveDir * movmentSpeed;

    }
}
