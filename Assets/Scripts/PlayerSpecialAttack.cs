using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpecialAttack : MonoBehaviour
{
    public GameObject sab;
    public Slider slider;
    public GameObject Rogi;
    public Transform AttackPos;
    public LayerMask Enemies;
    public float RangeAttack;
    public int damage = 80;
    public bool hit = false;
    Animator HeroAnimCont;
    public GameObject EfektPlayer;
    public GameObject EfektEnemy;
    public float StunTime = 200f;
    Vector3 positione; 


    void Start()
    {
        slider = sab.GetComponent<Slider>();
        HeroAnimCont = GetComponent<Animator>();
    }

    IEnumerator Cosbdzieje()
    {
        hit = true;
        yield return new WaitForSeconds(1.0f);
        hit = false;
    }

    //IEnumerator Stunned()
    //{
       // Collider2D[] EnemyCheck = Physics2D.OverlapCircleAll(AttackPos.position, RangeAttack, Enemies);
       // foreach (Collider2D enemy in EnemyCheck)
       // {

         //  enemy.GetComponent<Prawieworkingslime>().enabled = false;
          // yield return new WaitForSeconds(StunTime);
//enemy.GetComponent<Prawieworkingslime>().enabled = true;
      // }
   // }

    public void Update()
    {
        if (slider.value == 10f)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
                StartCoroutine(Cosbdzieje());
                HeroAnimCont.SetBool("SA", true);
                Instantiate(EfektPlayer, Rogi.transform.position, Quaternion.identity);
            }            
        }
        else
        {
            HeroAnimCont.SetBool("SA", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPos.position, RangeAttack);
    }


    private void Attack()
    {
        
        Collider2D[] DealingDamage = Physics2D.OverlapCircleAll(AttackPos.position, RangeAttack, Enemies);
        foreach (Collider2D enemy in DealingDamage)
        {
            enemy.GetComponent<Transform>();
            enemy.GetComponent<EnemyDamage>().TakeDamage(damage);
            //StartCoroutine(Stunned());
            positione = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - 2);
            //Instantiate(EfektEnemy, positione, Quaternion.identity);

            GameObject efekcik = Instantiate(EfektEnemy, positione, Quaternion.identity);
            efekcik.transform.SetParent(enemy.transform);
        }

    }
}
