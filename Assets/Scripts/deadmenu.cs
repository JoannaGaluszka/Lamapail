using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadmenu : MonoBehaviour
{
    public GameObject DeadMenu;
    private GameObject Player;
    private CheckpointManager CM;
    public GameObject Canvas;
    public bool Umar = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        CM = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManager>();
    }

    void Update()
    {
        if (DeadMenu.activeSelf == true)
        {
            Time.timeScale = 0f;
            Canvas.SetActive(false);
            Umar = true;
        }
        else
            Canvas.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Reload()
    {
        Player.transform.position = CM.LastCheckPos;
        Umar = false;
        Time.timeScale = 1f;
    }
}
