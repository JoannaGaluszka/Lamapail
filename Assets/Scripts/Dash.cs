using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;

    public float dashSpeed;
    public float speed;
    float dashTime;
    public float startDashTime;
    float resetDash;
    public float startResetDash;

    int direction;

    bool dashing;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    private void Update()
    {
        Dash();

         if (!dashing)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        }

        void Dash()
        {
            if(direction == 0)
            {
                resetDash -= Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if(Input.GetAxisRaw("Horizontal") > 0)
                    {
                        direction = 1;

                    }
                    else if(Input.GetAxisRaw("Horizontal") < 0)
                    {
                        direction = 2;
                    }
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    if (resetDash >= 0)
                    {
                        rb.velocity = Vector2.zero;
                        dashing = false;
                    }
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if(resetDash <= 0)
                    {
                        if(direction == 1)
                        {
                            rb.velocity = Vector2.right * dashSpeed;
                            resetDash = startResetDash;
                            dashing = true;
                        }
                        else if(direction == 2)
                        {
                            rb.velocity = Vector2.left * dashSpeed;
                            resetDash = startResetDash;
                            dashing = true;
                        }
                    }
                }
            }
        }
    }

}
    

       
