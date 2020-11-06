using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on, off;
    public bool isOn = false;
    public DoorController doors;
    public bool TriggerEntered;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = off;
        TriggerEntered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered = true;
        Debug.Log("kolizja dzwignia !!!");

        if (Input.GetKeyDown(KeyCode.E)) {
            Use();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Dzwigna exit");
        TriggerEntered = false;
    }
    private void Use()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = on;
        isOn = true;
        doors.Open();
        Debug.Log("FLIP !!!");
    }
}
