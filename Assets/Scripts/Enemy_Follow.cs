using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    public float speed;
    public float HP;
    
    //szybkosc poruszana sie enemy
    public float stop;
    public float backdistance;
    public float DetectionRadius;
    public Transform AttackDistance;
    public LayerMask PlayerLayer;

    public bool playerInRange;
    public bool facingRight = false;


    private float czaMiedzStrz;
    public float czaRozpoczStrz;

    public GameObject projectile;
    private Transform target;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackDistance.position, DetectionRadius);
    }
   

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        czaMiedzStrz = czaRozpoczStrz;
    }


    void Update()
    {
        
        playerInRange = Physics2D.OverlapCircle(transform.position, DetectionRadius, PlayerLayer);


        if (playerInRange)
        {
            if (Vector2.Distance(transform.position, target.position) > stop)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < stop && Vector2.Distance(transform.position, target.position) > backdistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, target.position) < backdistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }

            if (target.transform.position.x < gameObject.transform.position.x && facingRight)
                Flip();
            if (target.transform.position.x > gameObject.transform.position.x && !facingRight)
                Flip();


            if (czaMiedzStrz <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                //quaternion.identity, brak obrotu
                czaMiedzStrz = czaRozpoczStrz;
            }
            else
            {
                czaMiedzStrz -= Time.deltaTime;
            }


        }
        void Flip()
        {
            
            facingRight = !facingRight;
            Vector3 tmpScale = gameObject.transform.localScale;
            tmpScale.x *= -1;
            gameObject.transform.localScale = tmpScale;
        }





    }
    }


