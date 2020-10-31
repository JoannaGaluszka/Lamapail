
using System.Collections;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float Cooldown;
    public float startCooldown;
    public Transform AttackPos;
    public LayerMask whoisenemy;
    public float attackRange;
    public int DMG;

    void Update()
    {
        if (Cooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, attackRange, whoisenemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().DamageTaken(DMG);
                }
                Cooldown = startCooldown;
            }
            else
            {
                Cooldown -= Time.deltaTime;

            }

        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AttackPos, attackRange);
        }
    }
}
