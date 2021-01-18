using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTrigger : MonoBehaviour
{
    Light2D lamp;
    Color color0 = Color.black;
    Color color1 = Color.yellow;
    void Start()
    {
        lamp = this.gameObject.GetComponent<Light2D>();
        Debug.Log(lamp);
        lamp.color = color0;
    }

    void OnTriggerStay2D()
    {
        lamp.color = color1;
    }
}
