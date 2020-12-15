using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchLevel : MonoBehaviour
{
    public int index;
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(index);
        }

        SceneManager.LoadScene(nextLevel);
    }

}
