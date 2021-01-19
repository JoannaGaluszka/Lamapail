using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private PointMng Licznik;
    int punkcik;
    // Start is called before the first frame update
    void Start()
    {
        Licznik = GameObject.Find("PointMng").GetComponent<PointMng>();
    }

    // Update is called once per frame
    void Update()
    {
        punkcik = Licznik.punkt;
        text.text = "SCORE:" + punkcik.ToString();
    }
}
