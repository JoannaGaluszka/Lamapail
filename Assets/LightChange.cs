using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightChange : MonoBehaviour
{
    Color color0 = Color.red;
    Color color1 = Color.green;
    Light2D lamp;

    void Start()
    {
        lamp = this.gameObject.GetComponent<Light2D>();
        Debug.Log(lamp);
    }

    void OnTriggerEnter2D()
    {
        lamp.color = color1;
    }
    void OnTriggerExit2D()
    {
        lamp.color = color0;
    }
}
