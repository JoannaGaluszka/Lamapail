using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on, off;
    public bool isOn;
    public DoorController doors;
    public bool TriggerEntered;
    private AudioSource open;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = off;
        TriggerEntered = false;
        isOn = false;
        open = GetComponent<AudioSource>();
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
        open.Play();
        isOn = true;
        doors.Open();
    }
}
