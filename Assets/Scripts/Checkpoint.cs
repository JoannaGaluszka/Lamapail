using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Triggered = false;
    Animator anim;
    private SoundMng soundMng;

    private CheckpointManager CM;

    void Start()
    {
        anim = GetComponent<Animator>();
        soundMng = FindObjectOfType<SoundMng>();
        CM = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManager>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            CM.LastCheckPos = transform.position;
            soundMng.Bonfire.Play();
            anim.SetBool("Triggered", true);
        }
    }


    void OnTriggerStay2D()
    {

        
    }
}

