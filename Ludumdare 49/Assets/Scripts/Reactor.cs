using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{

    int state = 0;

    public float difficulty;
    public float baseTime;

    float timeOnState;
    float maxTimeOnState;


    void Update()
    {
        timeOnState += Time.deltaTime;
        if(timeOnState >= maxTimeOnState)
        {
            NewStateActivate();
            state += 1;
            Debug.Log(state);
        }
    }

    void NewStateActivate()
    {
        maxTimeOnState = baseTime / Random.Range(1, difficulty);
        timeOnState = 0;
    }
}
