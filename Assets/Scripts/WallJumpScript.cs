using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask whatIsGround;
    private bool ground;
    private float moveInput;
    public float speed;


    public float WallCheckDistance;
    private bool TouchingWall;
    public Transform WallCheck;
    private bool WallSlide;
    public float WallSlideSpeed;

    private bool WallJump;
    public float WallForceHorizontal;
    public float WallForceVertical;
    public float WallJumpTime;
    private bool didWallJump = false;


    void Update()
    {
        if (ground)
        {
            didWallJump = false;
        }

        if (didWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        TouchingWall = Physics2D.Raycast(WallCheck.position, transform.right, WallCheckDistance, whatIsGround);

        if (TouchingWall == true && ground == false && moveInput != 0)
        {
            WallSlide = true;
        }
        else
        {
            WallSlide = false;
        }
        //zmiana charakterystyki rb przy slajdzie
        if (WallSlide)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlideSpeed, float.MaxValue));
            // Mathf.Clamp
            // rb.velocity.y -= WallSlideSpeed;
            // if (rb.velocity.y > float.MaxValue) {
            //     rb.velocity.y = float.MaxValue;
            // }
        }

        if (Input.GetKeyDown(KeyCode.Space) && WallSlide == true)
        {
            WallJump = true;
            Invoke("WallJumpBlock", WallJumpTime);
        }
        //fizyka odbicia i think
        if (WallJump == true)
        {                                                    //tu z jakiegoś powodu przy odbiciu nie nadaje -moveinput, nie odbija i nie odwraca postaci/
            didWallJump = true;
            rb.velocity = new Vector2(WallForceHorizontal * -moveInput, WallForceVertical);
            //rb.velocity = new Vector2(rb.velocity.x, WallForceVertical);
            //rb.AddForce(new Vector2(WallForceHorizontal * -moveInput, 0), ForceMode2D.Impulse);
            Debug.Log("odbicie");
            //Debug.Log(-moveInput);
            // Debug.Log(rb.velocity);
        }
    }
    private void WallJumpBlock()
    {
        WallJump = false;
        Debug.Log("WallJumpBlock");
    }
}
