using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float CzasMiedzyAtakiem;
    private float StartTime;

    public Transform AttackPos;
    public LayerMask Enemies;
    public float RangeAttack;
    public int damage;

    private void Update()
    {
        if (CzasMiedzyAtakiem <= 0)
        //mozna atakowac
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                Collider2D[] DealingDamage = Physics2D.OverlapCircleAll(AttackPos.position, RangeAttack, Enemies);
                for (int i = 0; i < DealingDamage.Length; i++)
                {
                    Debug.Log("Attack");
                }
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
}
