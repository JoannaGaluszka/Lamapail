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

        if(ground == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * ForceJump;
        }
    }
}


