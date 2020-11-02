using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_xy_following : MonoBehaviour
{
    public Transform player;
    public float range;
    public float moveSpeed;
    public float distance;
    private bool movingLeft = true;
    public Transform detection;
    

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
   
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        
        if (distance < range)
        {
            Following();
        }
        else
        {
            StopFollowing();
        }


        void Following()
        {
            if (transform.position.x < player.position.x)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
            }
        }

        void StopFollowing()
        {
            rb.velocity = new Vector2(0, 0);
        }

        RaycastHit2D ground = Physics2D.Raycast(detection.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;

            }
        }

    }
    
}

