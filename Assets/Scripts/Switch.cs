using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on, off;

    public bool isOn = false;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = off;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = on;

        isOn = true;
      

    }
}
