using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    private HP Player;

    public int PickUp;

    private void Awake()
    {
        Player = FindObjectOfType<HP>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Player.zycie < Player.iloscSerc)
        {
            Destroy(gameObject);
            Player.zycie = Player.zycie + PickUp;
        }
    }
}
