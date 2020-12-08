using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   public float Speed, PrawaGranica, LewaGranica;
   public bool moveRight;
    void Update()
    {
        if (transform.position.x > PrawaGranica)
            moveRight = false;
        if (transform.position.x < LewaGranica)
            moveRight = true;
        if (moveRight)
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
    }
}
