using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject effect;
    public GameObject DeadMenu;
    private AudioSource GameOverSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameOverSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameOverSound.Play();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
       
           

            DeadMenu.SetActive(true);

        }
        else
        {
            if (other.gameObject.CompareTag("Ground"))
                Destroy(gameObject);
        }

        
       
    }
   

}
