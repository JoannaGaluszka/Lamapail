using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingpadzik : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 startPos;

    public bool respawn = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Invoke("FallingPadzik", 0.2f);
        }
    }
    void FallingPadzik()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 3f);
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = startPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone" && respawn)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = startPos;
        }
    }

}