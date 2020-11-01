using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool Zmiana;
    public bool is_flipped;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        is_flipped = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (is_flipped == false)
            {
                anim.SetBool("LeverFlip", true);
                is_flipped = true;
            }
            else
            {
                anim.SetBool("LeverFlip", false);
                is_flipped = false;
            }
        }
    }
    void OnTriggerStay2D()
    {
        
        
    }


}
