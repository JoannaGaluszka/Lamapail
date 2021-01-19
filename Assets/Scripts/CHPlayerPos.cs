using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHPlayerPos : MonoBehaviour
{
    public Vector3 StartPos;
    void Start()
    {
        transform.position = StartPos;
    }

 
}
