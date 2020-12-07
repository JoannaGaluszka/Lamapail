using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float DetectionRadius;

    public bool playerInRange;

    private HP Player;
    private Transform player;
    public LayerMask PlayerLayer;
    private Vector2 target;
    public float liveTime = 1.5f;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    private void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, DetectionRadius, PlayerLayer);
        
        if (playerInRange)
        {

            //zamiast target, mozna zastosowac player.position, projectile bedzie followowac 
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            
                if (transform.position.x == target.x && transform.position.y == target.y)
            {     
                {
                    DestroyProjectile();
                }
            }
            else
            {
                liveTime -= Time.deltaTime;
                if (liveTime <= 0)
                {
                    DestroyProjectile();
                }
            }
        }        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            Player.Damage(1);
        }


    }


    void DestroyProjectile()
    {
        {
            Destroy(gameObject);
        }
    }

}

