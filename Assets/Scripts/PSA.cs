using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSA : MonoBehaviour
{
    private Slider slider;
    private float startingTime = 0f;
    public Image[] bar;
    public Sprite normalBar, glowBar, normalPin, glowPin;
    public GameObject player;
    bool atak;

    public Image srBar, srPin;

    void Start()
    {
        slider = GetComponent<Slider>();
        SetMax(10);
        srBar = this.transform.Find("bartile_0").GetComponent<Image>();
        srPin = this.transform.Find("nextbartile_0").GetComponent<Image>();
    }

    public void SetMax(int valuee)
    {
        slider.maxValue = valuee;
    }

    public void Update ()
    {
        atak = player.GetComponent<PlayerSpecialAttack>().hit;
        startingTime += Time.deltaTime;
        slider.value = startingTime;

        if (startingTime >= slider.maxValue)
        {
            startingTime = 10f;
            slider.value = 10f;
            bar[0].sprite = glowBar;
            bar[1].sprite = glowPin;
            
        }
        if (atak)
        {

            startingTime = 0f;
            slider.value = 0f;
            bar[0].sprite = normalBar;
            bar[1].sprite = normalPin;

        }
    }

}
