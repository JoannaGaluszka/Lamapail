using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prawieworkingslime : MonoBehaviour
{
    public float HP;
    public float speed;
    public float DetectionRadius;

    public bool MoveRight;
    
    public Transform AttackDistance;
    public LayerMask StartAttack;
    private HP Player;
    

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackDistance.position, DetectionRadius);
    }

   

        void Update()

    {
        
        

        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }

        if (Physics2D.OverlapCircle(AttackDistance.position, DetectionRadius, StartAttack))
        {
            Debug.Log("Detekcja");
            speed = 0.3f;
        }
        else
        {
            speed = 2;
        }
    }

    
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {

            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
        
    }

    void Attack()
    {
        Debug.Log("Detekcja");

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.Damage(1);
        }
    }

}
