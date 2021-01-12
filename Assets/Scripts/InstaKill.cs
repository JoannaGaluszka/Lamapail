using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    public PlayerController player;
    public GameObject effect;
    public GameObject DeadMenu;
    public AudioSource GameOverSound;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        GameOverSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            GameOverSound.Play();
            DeadMenu.SetActive(true);
        }
    }
}
