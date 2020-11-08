using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presspad : MonoBehaviour
{
    public bool IsOn = false;
    public DoorController WhatToTrigger;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    void OnTriggerStay2D()
    {
        anim.SetBool("TransitionPad", true);
        IsOn = true;
        WhatToTrigger.Open();
    }
    void OnTriggerExit2D()
    {
        anim.SetBool("TransitionPad", false);
        IsOn = false;
        WhatToTrigger.Close();
    }
}
