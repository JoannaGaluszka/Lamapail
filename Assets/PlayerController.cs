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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        ground = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);
<<<<<<< HEAD
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        } else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        
=======
>>>>>>> 12fad648197a89d1eb5d16a9735a2b87e77f1135

        if(ground == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * ForceJump;
        }
    }
}


