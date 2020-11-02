using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
<<<<<<< HEAD
=======
    
>>>>>>> master
    public int maxHealth = 300;
    int currentHealth;
    private Rigidbody2D rb;
    SpriteRenderer sprite;

<<<<<<< HEAD
=======

>>>>>>> master
    void Start()
    {
        currentHealth = maxHealth;
        rb = transform.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Take " + damage + " damage");
        StartCoroutine(HitColor());
        rb.AddForce(transform.up * 60, ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }

    IEnumerator HitColor()
    {
        sprite.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(255, 255, 255, 255);
    }

<<<<<<< HEAD
}
=======
}
>>>>>>> master
