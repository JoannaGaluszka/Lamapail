using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, 2, transform.position.z);
    }
}

