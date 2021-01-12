using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 300;
    int currentHealth;
    private Rigidbody2D rb;
    SpriteRenderer sprite;
    public GameObject effect;
    public GameObject blood;
    public GameObject item;
    private SoundMng soundMng;





    void Start()
    {
        currentHealth = maxHealth;
        rb = transform.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        soundMng = FindObjectOfType<SoundMng>();


    }


        public void TakeDamage(int damage)
        {
            
            currentHealth -= damage;
            
            Instantiate(blood, transform.position, Quaternion.identity);
            Debug.Log("Take " + damage + " damage");
            StartCoroutine(HitColor());
            rb.AddForce(transform.up * 60, ForceMode2D.Impulse);
            soundMng.playerHurt.Play();


        if (currentHealth <= 0)
            {
                
                Die();
            }


        }

        void Die()
        {
            
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            Debug.Log("Enemy died!");
            Instantiate(item, transform.position, Quaternion.identity);
            
        }

        IEnumerator HitColor()
        {
            sprite.color = new Color(255, 0, 0, 255);
            yield return new WaitForSeconds(0.1f);
            sprite.color = new Color(255, 255, 255, 255);
        }
    
    

}
