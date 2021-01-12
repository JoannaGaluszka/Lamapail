using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float CzasMiedzyAtakiem = 2f;
    private float StartTime;

    public Transform AttackPos;
    public LayerMask Enemies;
    public float RangeAttack;
    public int damage = 40;
    private SoundMng soundMng;

    private void Start()
    {
        soundMng = FindObjectOfType<SoundMng>();
    }
    private void Update()
    {
        if (CzasMiedzyAtakiem <= 0)
        //mozna atakowac
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                Debug.Log("Attack");
                soundMng.playerAttack.Play();
            }


            CzasMiedzyAtakiem = StartTime;
        }
        else
        {
            CzasMiedzyAtakiem -= Time.deltaTime;


        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(AttackPos.position, RangeAttack);
    }

    

    private void Attack()
    {
        //Check for enemies in AttackPos object
        Collider2D[] DealingDamage = Physics2D.OverlapCircleAll(AttackPos.position, RangeAttack, Enemies);

        //Loop through enemies if any and deal damage to them
        foreach (Collider2D enemy in DealingDamage)
        {
            enemy.GetComponent<EnemyDamage>().TakeDamage(damage);
        }

    }
}
