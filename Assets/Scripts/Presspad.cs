using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presspad : MonoBehaviour
{
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
    }
    void OnTriggerExit2D()
    {
        anim.SetBool("TransitionPad", false);
    }
}
