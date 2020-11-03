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

        if(czaMiedzStrz <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            //quaternion.identity nie ma rotacji
            czaMiedzStrz = czaRozpoczStrz;
        }
        else
        {
            czaMiedzStrz -= Time.deltaTime;
        }

        } 
    }


