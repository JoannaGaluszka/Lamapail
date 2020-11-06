using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passing : MonoBehaviour
{
    private PlatformEffector2D przejscie;
    public float CzasOczek;

    private void Start()
    {
        przejscie = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S)) {
            CzasOczek = 0.3f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (CzasOczek <= 0)
            {
                przejscie.rotationalOffset = 180;
                CzasOczek = 0.3f ;
            }
            else
            {
                CzasOczek -= Time.deltaTime;


            }
        }
        if (Input.GetKey(KeyCode.Space)){
            przejscie.rotationalOffset = 0;
        }
    }
}
