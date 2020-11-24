using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpecialAttack : MonoBehaviour
{
    public GameObject sab;
    private Slider slider;

    public Transform AttackPos;
    public LayerMask Enemies;
    public float RangeAttack;
    public int damage = 80;
    public bool hit = false;


    void Start()
    {
        slider = sab.GetComponent<Slider>();
    }

    IEnumerator Cosbdzieje()
    {
        hit = true;
        yield return new WaitForSeconds(1.0f);
        hit = false;
    }

    public void Update()
    {
        if (slider.value == 10f)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
                StartCoroutine (Cosbdzieje());
            }
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
            enemy.GetComponent<EnemyDamage>().TakeDamage(damage);
        }

    }

    
}
