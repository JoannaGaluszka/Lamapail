using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKillKolcow : MonoBehaviour
{
    public PlayerController player;
    public GameObject effect;
    public GameObject DeadMenu;
    SpriteRenderer SR;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        SR = gameObject.GetComponent<SpriteRenderer>();
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        SR.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            DeadMenu.SetActive(true);
            SR.enabled = false;
            StartCoroutine(Respawn());
        }
    }
}
