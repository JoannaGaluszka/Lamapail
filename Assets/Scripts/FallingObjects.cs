using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject effect;
    public GameObject DeadMenu;
    private SoundMng soundMng;
    public new Vector3 poz;
    SpriteRenderer SR;
    public bool mozna = true;
    BoxCollider2D BX2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundMng = FindObjectOfType<SoundMng>();
        poz = transform.position;
        BX2D = gameObject.GetComponent<BoxCollider2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();

    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        rb.velocity = new Vector2(0, 0);
        BX2D.enabled = true;
        gameObject.transform.position = poz;
        SR.enabled = true;
        rb.isKinematic = true;
        mozna = true;
        
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
        if (mozna == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                soundMng.playerDead.Play();
                Instantiate(effect, transform.position, Quaternion.identity);



                DeadMenu.SetActive(true);

            }
            else
            {
                if (other.gameObject.CompareTag("Ground"))
                {
                    StartCoroutine(Respawn());
                    
                    
                    SR.enabled = false;
                    mozna = false;
                    BX2D.enabled = false;

                }
            }
        }

        
       
    }
   

}
