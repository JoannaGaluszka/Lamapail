using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on, off;
    public bool isOn;
    public DoorController doors;
    public bool TriggerEntered;
    private SoundMng soundMng;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = off;
        TriggerEntered = false;
        isOn = false;
        soundMng = FindObjectOfType<SoundMng>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered = true;   
    }

    void Update()
    {
        if (TriggerEntered == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
                Use();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerEntered = false;
    }

    private void Use()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = on;
        soundMng.open.Play();
        isOn = true;
        doors.Open();
    }
}
