using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;
    public Transform Poczuntek;
    public Transform Konic;

    public float max;
    public float min;

    void Start()
    {
        min = Poczuntek.transform.position.x + 2f;
        max = Konic.transform.position.x - 2f;
    }

    void FixedUpdate ()
    {

        if (Player.position.x > min && Player.position.x < max)
        {
            transform.position = new Vector3(Player.position.x, 2, -5);
        }
        
    }
}