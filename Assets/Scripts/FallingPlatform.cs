using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FallingPlatform : MonoBehaviour

{
    private Rigidbody2D rb;
    Vector2 startPos;
    private SpriteRenderer Spr;
    private BoxCollider2D coll;
    public float CzasWywołania;
    public float RespawnTime;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Spr = GetComponent<SpriteRenderer>();
        startPos = transform.position;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  
        {
            Invoke("FallingPad", CzasWywołania);
        }
    }
    void FallingPad()
     {
     rb.isKinematic = false;
     Spr.sortingLayerName = "Mid";
     Invoke("ColliderOFF", 0.15f);
     Invoke("Respawn", RespawnTime);
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