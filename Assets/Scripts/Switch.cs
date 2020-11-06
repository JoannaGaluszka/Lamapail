using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite on, off;
    public bool isOn = false;
    public DoorController doors;
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = on;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (Input.GetKeyDown(KeyCode.E)) nie ogarniam bomby czemu to nie działa 
        gameObject.GetComponent<SpriteRenderer>().sprite = off;

        isOn = true;
        doors.Open();
    }
}
