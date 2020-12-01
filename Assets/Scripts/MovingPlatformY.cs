using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformY : MonoBehaviour
{
    public float Speed, GGranica, DGranica;
    public bool moveUp;
    void Update()
    {
        if (transform.position.y > GGranica)
            moveUp = false;
        if (transform.position.y < DGranica)
            moveUp = true;
        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);

    }
}
