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

    PlayerMovement player;


    void Update()
    {
        timeOnState += Time.deltaTime;
        if(timeOnState >= maxTimeOnState)
        {
            NewStateActivate();
            state += 1;
        }
    }

    void NewStateActivate()
    {
        maxTimeOnState = baseTime / Random.Range(1, difficulty);
        timeOnState = 0;
    }

    public void Fix()
    {
        Debug.Log("fixed");
        state = 0;
        NewStateActivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            player.handObject.Reactor = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.handObject.Reactor = null;
        }
    }
}
