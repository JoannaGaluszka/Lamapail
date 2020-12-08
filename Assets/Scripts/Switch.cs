using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on, off;
    public bool isOn;
    public DoorController doors;
    public bool TriggerEntered;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = off;
        TriggerEntered = false;
        isOn = false;
    }
    //warunek do flipka
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered = true;
        //Debug.Log("kolizja dzwignia !!!");    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //wywołanie funkcji nie wiem czy to ma sens XD
        if(Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Dzwigna exit");
        TriggerEntered = false;
    }
    private void Use()
    {
    //mongołowie lepiej by to napisali niż ja (no offense intended)
        gameObject.GetComponent<SpriteRenderer>().sprite = on;
        isOn = true;
        doors.Open();
        //Debug.Log("FLIP !!!");
    }
}
