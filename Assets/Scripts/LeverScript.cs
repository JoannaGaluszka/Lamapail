using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool Zmiana;
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
        if (Input.GetKeyDown(KeyCode.F))
        anim.SetBool("LeverFlip", true);
    }


}
