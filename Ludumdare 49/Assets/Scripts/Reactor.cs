using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{

    public int state = 0;

    [SerializeField]
    Animator animator;

    [System.Serializable]
    public class ReactorData
    {
        public string name;
        public Reactor reactor;

        public bool active;
        public float difficulty;
        public float baseTime;
    }


    float timeOnState;
    float maxTimeOnState;

    PlayerMovement player;

    bool active = true;
    float difficulty = 2;
    float baseTime = 10;

    public void SetData(ReactorData reactorData)
    {
        active = reactorData.active;
        difficulty = reactorData.difficulty;
        baseTime = reactorData.baseTime;
    }


    void Update()
    {
        if (active)
        {
            timeOnState += Time.deltaTime;
            if (timeOnState >= maxTimeOnState)
            {
                NewStateActivate();
                state += 1;
                animator.SetFloat("State", state);
            }
        }

        if (state == 1)
        {
            animator.SetTrigger("yks");
        }
        if (state == 2)
        {
            animator.SetTrigger("kaks");
        }
        if (state == 3)
        {
            animator.SetTrigger("kolme");
        }
        if (state == 4)
        {
            animator.SetTrigger("nelja");
            active = false;
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
        state = 1;
        animator.SetFloat("State", state);
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

    public void Activate()
    {
        active = true;
    }
    public void ChangeDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
    }
}
