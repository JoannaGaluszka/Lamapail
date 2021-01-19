using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMng : MonoBehaviour
{
    public static PointMng instance;
    public Text text;
    public int punkt;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ZmienWynik(int CherryValue)
    {
        punkt += CherryValue;
        text.text = "X" + punkt.ToString();

    }
}
