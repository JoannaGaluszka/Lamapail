using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    public PlayerController player;
    public GameObject effect;
    public GameObject DeadMenu;
    private SoundMng soundMng;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        soundMng = FindObjectOfType<SoundMng>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            soundMng.playerDead.Play();
            DeadMenu.SetActive(true);
        }
    }
}
