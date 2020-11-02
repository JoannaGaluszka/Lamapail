using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    public bool isOn = false;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Off.GetComponent<SpriteRenderer>().sprite;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = On.GetComponent<SpriteRenderer>().sprite;

        isOn = true;

    }
}
