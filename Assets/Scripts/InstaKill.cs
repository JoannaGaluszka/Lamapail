using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    public PlayerController player;
    public GameObject effect;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
