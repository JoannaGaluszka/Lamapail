using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presspad : MonoBehaviour
{
    public bool IsOn = false;
    public DoorController WhatToTrigger;
    public GameObject Strzalka;

    Animator anim;
    private SoundMng soundMng;
    void Start()
    {
        anim = GetComponent<Animator>();
        soundMng = FindObjectOfType<SoundMng>();
    }

    void Update()
    {
       
    }
    void OnTriggerEnter2D()
    { soundMng.PressPad.Play();
        anim.SetBool("TransitionPad", true);
        IsOn = true;
        WhatToTrigger.Open();
        Strzalka.SetActive(true);
    }

    void OnTriggerStay2D()
    {
        


    }
    void OnTriggerExit2D()
    {
        
        anim.SetBool("TransitionPad", false);
        IsOn = false;
        WhatToTrigger.Close();
        soundMng.PressPad.Play();
    }
}
