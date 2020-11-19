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

    private bool ground;
    private bool Grab, Grabbing;


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

            // GRABBING I WALLJUMPING
            Grab = Physics2D.OverlapCircle(PunktZaczepienia.position, .2f, whatIsGround);

            Grabbing = false;
            if (Grab && !ground)
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

       

    

   

    


    
    

   


