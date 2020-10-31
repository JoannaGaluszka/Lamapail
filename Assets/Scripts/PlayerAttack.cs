using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool Beng = false;

    private float attackTimer = 0;
    private float attackCd = .35f;
    public Collider2D attackTrigger;
    public Transform AttackPos;
    private Animator anim;

    void Awake()
    {

        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !Beng)
        {
            Debug.Log("BOINK");
            Beng = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
           
        }

        if (Beng)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                Beng = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Czy atakuje", Beng);

    }
  

}

