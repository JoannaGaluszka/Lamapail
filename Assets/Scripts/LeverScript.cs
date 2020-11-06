using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool Zmiana;
    public bool is_flipped;
    private bool triggerEntered = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        is_flipped = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            if (is_flipped == false)
            {
                is_flipped = true;
            }
            else
            {
                is_flipped = false;
            }
            Debug.Log("Ciach");
        }
        
    }


}
