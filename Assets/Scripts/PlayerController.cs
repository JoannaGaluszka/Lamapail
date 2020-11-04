using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    private bool ground;
    public Transform feetPos;
    public float radius;
    public LayerMask whatIsGround;
    public float ForceJump;
    Animator HeroAnimCont;

    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HeroAnimCont = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
    
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
       
        
    }

    private void Update()
    {
        ground = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);
        //chodzonko
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        } else if (moveInput < 0)
        {

            transform.eulerAngles = new Vector2(0, 180);
        }
        //animatonko
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            HeroAnimCont.SetBool("Idzie", true);
        else
        {
            HeroAnimCont.SetBool("Idzie", false);
        }



        
        if (ground == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, ForceJump);
        }
       


    }



}


