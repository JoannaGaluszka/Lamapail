using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadmenu : MonoBehaviour
{
    public GameObject DeadMenu;

    void Update()
    {
        if (DeadMenu.activeSelf == true)
            Time.timeScale = 0f;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
