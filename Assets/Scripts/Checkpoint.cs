using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Triggered = false;
    Animator anim;
    private SoundMng soundMng;
    public bool Check = false;

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
            anim.SetBool("Triggered", true);
            if (!Check)
            {
                soundMng.Bonfire.Play();
                Check = true;
            }
        }

        
    }


    void OnTriggerStay2D()
    {

        
    }
}

