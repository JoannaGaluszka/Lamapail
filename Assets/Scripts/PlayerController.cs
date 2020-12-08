using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Transform feetPos;
    public LayerMask whatIsGround;
    Animator HeroAnimCont;
    public bool IsFacingRight;

    public float speed;
    public float moveInput;
    public float radius;
    public float ForceJump;

    public bool ground;
    private bool doubleJump;
    
    public int zycie;
    public int iloscSerc = 6;

    public Image[] heart;
    public Sprite full;
    public Sprite empty;

    private void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        HeroAnimCont = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsFacingRight = true;
        zycie = iloscSerc;

    }
    private void Update()
    {
        if(ground && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

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
        bool grounded = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);

        if (grounded)
        {
            ground = true;
        } else {
            ground = false;
        }

        //chodzonko
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0)
        {
            IsFacingRight = true;
            transform.eulerAngles = new Vector2(0, 0);           
        }
        else if (moveInput < 0)
        {
            IsFacingRight = false;
            transform.eulerAngles = new Vector2(0, 180);        
        }
        //animatonko
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            HeroAnimCont.SetBool("Idzie", true);
        else
        {
            HeroAnimCont.SetBool("Idzie", false);
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

    //skaczanko
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, ForceJump);
    }

    void Die()
    {
        //reset poziomu
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(int obrazenia)
    {
        zycie -= obrazenia;
    }
}


