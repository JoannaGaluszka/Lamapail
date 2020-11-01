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
        if (is_flipped == false) anim.SetBool("LeverFlip", true);
        else anim.SetBool("LeverFlip", false);
    }
    void OnTriggerEnter()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (is_flipped == false)
            {
                is_flipped = true;
            }
            else
            {
                is_flipped = false;
            }
        }
        
    }


}
