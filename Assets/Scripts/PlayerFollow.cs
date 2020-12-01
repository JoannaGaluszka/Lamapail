using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;
    [Range(0, 1)]
    public float k;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x, 2, transform.position.z), k);
    }
}

