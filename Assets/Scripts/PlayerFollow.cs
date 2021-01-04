using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;
    [Range(0, 1)]
    public float k = 1;
    private Vector3 velocity = new Vector3(1f, 1f, 1f);

    void FixedUpdate()
    {
        Vector3 desiredPos = new Vector3(Player.position.x, 2, transform.position.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, k);
        transform.position = smoothPos;
        //transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x, 2, transform.position.z), k);
    }
}

