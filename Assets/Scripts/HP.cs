using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int zycie;
    public int iloscSerc = 6;

    public Image[] heart;
    public Sprite full;
    public Sprite empty;
    public GameObject effect;
    public GameObject blood;
    public GameObject DeadMenu;
    public AudioSource GameOverSound;
    public AudioSource pickupSound;

    void Start()
    {
        zycie = iloscSerc;
        GameOverSound = GetComponent<AudioSource>();
        pickupSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        //hp gracza, zmiana sprite
        if (zycie > iloscSerc)
        {
            zycie = iloscSerc;
        }
        for (int i = 0; i < heart.Length; i++)
        {
            //jesli i jest mniejsze od ilosci zycia, pojawia sie full sprite 
            if (i < zycie)
            {
                heart[i].sprite = full;
            }
            else //jelsi i jest wieszke od ilosci zycia, zmienia sie na empty sprite
            {
                heart[i].sprite = empty;

                //jesli i jest mniejsze od ilosci serc, to chcemy aby serca byly widoczne 
                if (i < iloscSerc)
                {
                    heart[i].enabled = true;

                }
                else //jesli i jest wieksze od ilosci serc, to chcemy aby serca byly ukryte 
                {
                    heart[i].enabled = false;
                }
            }
        }
        if (zycie > iloscSerc)
        {
            zycie = iloscSerc;
        }
        if (zycie <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            
            Die();
            

        }

    }
    void Die()
    {
        GameOverSound.Play();
        DeadMenu.SetActive(true);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            pickupSound.Play();
            Destroy(other.gameObject);
        }
    }
    public void Damage(int obrazenia)
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        zycie -= obrazenia;
    }

}