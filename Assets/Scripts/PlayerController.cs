using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform feetPos;
    public LayerMask whatIsGround;
    Animator HeroAnimCont;
    public Transform PunktZaczepienia;

    public float speed;
    public float ForceJump;
    private float Grawitacja;
    public float wallJump = 0.2f;
    private float WallJumpReverse;
    private float DirectionDash;
    private float ActualDash;
    public float DashForce;
    public float StartDash;
    private float moveInput;

    private bool ground;
    private bool Grab, Grabbing;
    public bool Dash;

    public float cooldownTime = 1.25f;
    public float nextCooldownTime = 0;

    public GameObject dashEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HeroAnimCont = GetComponent<Animator>();
        Grawitacja = rb.gravityScale;



    }
    private void Update()
    {
        if (WallJumpReverse <= 0)
        {
            //CHODZENIE I SKAKANIE
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

            ground = Physics2D.OverlapCircle(feetPos.position, 0.2f, whatIsGround);

            if (Input.GetButtonDown("Jump") && ground)
            {
                rb.velocity = new Vector2(rb.velocity.x, ForceJump);
            }
            // FLIP
            if (rb.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1, 1f);
            }
            //DASH
            if (Time.time > nextCooldownTime)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) && moveInput != 0)
                {

                    Dash = true;
                    ActualDash = StartDash;
                    rb.velocity = Vector2.zero;
                    DirectionDash = moveInput;
                    nextCooldownTime = Time.time + cooldownTime;
                    
                }
            }

                if (Dash)
                {
                    
                    rb.velocity = transform.right * DirectionDash * ForceJump;
                    ActualDash -= Time.deltaTime;
                    if (ActualDash <= 0)
                    {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    Dash = false;
                        
                }
                }
            

            // GRABBING I WALLJUMPING
            Grab = Physics2D.OverlapCircle(PunktZaczepienia.position, .2f, whatIsGround);

            Grabbing = false;
            if (Grab)
            {
                if ((transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0))
                {
                    Grabbing = true;
                }
            }

            if (Grabbing)
            {
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;

                if (Input.GetButtonDown("Jump"))
                {
                    WallJumpReverse = wallJump;

                    rb.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * speed, ForceJump);
                    rb.gravityScale = Grawitacja;
                    Grabbing = false;
                }
            }
            else
            {
                rb.gravityScale = Grawitacja;
            }
        }
        else
        {
            WallJumpReverse -= Time.deltaTime;
        }


        //animatonko
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            HeroAnimCont.SetBool("Idzie", true);
        else
        {
            HeroAnimCont.SetBool("Idzie", false);
        }

    }

}

       

    

   

    


    
    

   


