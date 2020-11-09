using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingSlime : MonoBehaviour
{
    private CapsuleCollider2D CC2D;
    public float MocWyrzutu;
    // Start is called before the first frame update
    void Start()
    {
        CC2D = GetComponent<CapsuleCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>
                ().AddForce(new Vector2(0f,MocWyrzutu), ForceMode2D.Impulse);

            Debug.Log("kolizja");
        }
    }
}
