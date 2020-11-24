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

    public float speed;
    private float moveInput;
    public float radius;
    public float ForceJump;

    private bool ground;
    private bool doubleJump;
    //walljump 7.11 aj
    public float WallCheckRadius;
    private bool TouchingWall;
    public Transform WallCheck;
    private bool WallSlide;
    public float WallSlideSpeed;
    //++++
    private bool WallJump;
    public float WallForceHorizontal;
    public float WallForceVertical;
    public float WallJumpTime;

    public int zycie;
    public int iloscSerc =6;

    public Image[] heart;
    public Sprite full;
    public Sprite empty;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HeroAnimCont = GetComponent<Animator>();

        zycie = iloscSerc;

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");   
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);           
    }

    private void Update()
    {

        //hp gracza, zmiana sprite
        if (zycie > iloscSerc)
        {
            zycie = iloscSerc;
        }
        for (int i = 0; i < heart.Length; i++)
        {
            //jesli i jest mniejsze od ilosci zycia, pojawia sie full sprite 
            if (i < zycie)
            {
                heart[i].sprite = full;
            }
            else //jelsi i jest wieszke od ilosci zycia, zmienia sie na empty sprite
            {
                heart[i].sprite = empty;

                //jesli i jest mniejsze od ilosci serc, to chcemy aby serca byly widoczne 
                if (i < iloscSerc)
                {
                    heart[i].enabled = true;

                }
                else //jesli i jest wieksze od ilosci serc, to chcemy aby serca byly ukryte 
                {
                    heart[i].enabled = false;
                }
            }
        }
        ground = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);
        //chodzonko
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (moveInput < 0)
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



        //skaczanko
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                rb.velocity = Vector2.up * ForceJump;
                //doubleJump = true;
            }
            //else
            //{
            //    if (doubleJump)
            //    {
            //        doubleJump = false;
            //        rb.velocity = new Vector2(rb.velocity.x, 0);
            //        rb.velocity = new Vector2(rb.velocity.x, ForceJump);
            //    }
            //}
            
        }
        //Double Jump Conditions uwu
        TouchingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, whatIsGround);

        if(TouchingWall == true && ground == false && moveInput != 0)
        {
            WallSlide = true;
        } else
        {
            WallSlide = false;
        }
        //zmiana charakterystyki rb przy slajdzie
        if (WallSlide)
        {                                                                    
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlideSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.Space) && WallSlide == true)
        {
            WallJump = true;
            Invoke("WallJumpBlock", WallJumpTime);
        }
        //fizyka odbicia i think
        if (WallJump == true)
        {                                                    //tu z jakiegoś powodu przy odbiciu nie nadaje -moveinput, nie odbija i nie odwraca postaci/
            rb.velocity = new Vector2(WallForceHorizontal * -moveInput, WallForceVertical);
            Debug.Log("odbicie");
        }


        if (zycie > iloscSerc)
        {
            zycie = iloscSerc;
        }
        if (zycie <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        //reset poziomu
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int obrazenia)
    {
        zycie -= obrazenia;
    }

    private void WallJumpBlock()
    {
        WallJump = false;
        Debug.Log("WallJumpBlock");
    }

}


