using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 startPos;
    public SpriteRenderer Spr;
    private BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Spr = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Invoke("FallingPadzik", 0.4f);
        }
    }
    void FallingPadzik()
    {
        rb.isKinematic = false;
        Spr.sortingLayerName = "Mid";
        Invoke("ColliderOFF", 0.15f);
        Invoke("Respawn", 3.75f);
        
        
    }
    void ColliderOFF()
    {
        coll.enabled = false;
    }
    void Respawn()
    {
        transform.position = startPos;
        Spr.sortingLayerName = "Platforms";
        rb.isKinematic = true;
        rb.velocity = new Vector2(0, 0);
        coll.enabled = true;
    }

}