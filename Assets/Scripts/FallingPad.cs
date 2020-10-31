using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPad : MonoBehaviour
{
    public BoxCollider2D cd;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter(Collider cd)
    {
        
            Invoke("PlatformFall", 0.1f);
            Destroy(gameObject, 2f);
        
    }
     void PlatfornFall()
    {
        rb.isKinematic = false;
    }

}
