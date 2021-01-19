using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTrigger : MonoBehaviour
{
    Light2D lamp;
    Color color0 = Color.black;
    Color color1 = Color.yellow;
    private bool Ognicho = false;
    void Start()
    {
        lamp = this.gameObject.GetComponent<Light2D>();
        Debug.Log(lamp);
        lamp.color = color0;
    }

    void Update()
    {
        if(Ognicho == true)
            lamp.color = color1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Ognicho = true;
        }
    }
}
