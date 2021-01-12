using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{
    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerAttack;
    public AudioSource jump;
    public AudioSource PickUp;
    public AudioSource open;
    public AudioSource dash;


    private static bool audioMngExists;
    void Start()
    {
        if (!audioMngExists)
        {
            audioMngExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
