using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float HP;
    public float speed;
    public float distance;
    private bool movingLeft = true;
    public Transform detection;
    public GameObject BoinkEffect;

    // private Animator Cycle       <-------------Przy gotowych spritach bedziemy kombinowac // dodać start przy animatorze
    public GameObject Particle;
   
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(detection.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;

            }
        }

        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        
    }
    public void DamageTaken(int DMG)
    {
        Instantiate(BoinkEffect, transform.position, Quaternion.identity);
        HP -= DMG;
        Debug.Log("zabolało");
    }
}