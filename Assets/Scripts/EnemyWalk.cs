using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingLeft = true;
    public Transform detection;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(detection.position, Vector2.down, distance);
        //RaycastHit2D tree1 = Physics2D.Raycast(detection.position, Vector2.left, distance);
        //RaycastHit2D tree2 = Physics2D.Raycast(detection.position, Vector2.right, distance);

        if (ground.collider == false || transform.position.x < -31 || transform.position.x > 130)
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
