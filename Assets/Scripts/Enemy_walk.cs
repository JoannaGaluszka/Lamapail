using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingLeft = true;
    public Transform detection;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(detection.position, Vector2.down, distance);
        if (ground.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;

            }
        }
    }
}
