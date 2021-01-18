using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class lightSwitch : MonoBehaviour
{
    Light2D lamp;
    Color color0 = Color.red;
    Color color1 = Color.green;
    public bool TriggerEntered;

    void Start()
    {
        lamp = this.gameObject.GetComponent<Light2D>();
        Debug.Log(lamp);
        lamp.color = color0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered = true;
    }

    void Update()
    {
        if (TriggerEntered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
                lamp.color = color1;
        }
    }
}
