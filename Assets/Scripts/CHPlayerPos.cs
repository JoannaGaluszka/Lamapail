using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHPlayerPos : MonoBehaviour
{
    private CheckpointManager CM;
    void Start()
    {
        CM = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointManager>();
        transform.position = CM.LastCheckPos;
    }

 
}
