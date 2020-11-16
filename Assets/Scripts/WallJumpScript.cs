using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpScript : MonoBehaviour
{
    public float WallCheckDistance;
    private bool WallSlide;
    public float WallSlideSpeed;

    public float WallJumpTime;
    RaycastHit2D WallCheckHit;
    private float JumpTime;
    public float WallForceX;
    public float WallForceY;

    public LayerMask GroundLayer;

    public PlayerController pc;
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");     
        if (pc.IsFacingRight)
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(WallCheckDistance, 0), WallCheckDistance, GroundLayer);
           Debug.DrawRay(transform.position, new Vector2(WallCheckDistance, 0), Color.blue);
        } else {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-WallCheckDistance, 0), WallCheckDistance, GroundLayer);
            Debug.DrawRay(transform.position, new Vector2(-WallCheckDistance, 0), Color.blue);

        }
        
        if (WallCheckHit && !pc.ground && moveInput != 0)
        {
            WallSlide = true;
            JumpTime = Time.time + WallJumpTime;
        } else if (JumpTime < Time.time)
        {
            WallSlide = false;
        }

        if (WallSlide)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, WallSlideSpeed, float.MaxValue));
        }       

        
        if (WallSlide && Input.GetKeyDown(KeyCode.Space))
        {
            if (pc.IsFacingRight)
            {
                WallJump(-WallForceX, WallForceY);             
            }
            else
            {
                WallJump(WallForceX, WallForceY);            
            }
        }

    }
    void WallJump(float x,float y)
    {
        rb.velocity = new Vector2(x, y);
    }
}
