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
    float difficulty = 1;
    float baseTime = 10;

    private CShake shake;

    public GameObject effect;

    public bool firstTime = false;

    public void SetData(ReactorData reactorData)
    {
        active = reactorData.active;
        difficulty = reactorData.difficulty;
        baseTime = reactorData.baseTime;
    }

    void Start()
    {
        shake = FindObjectOfType<CShake>();
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
            if (state == 4)
            {
                if(player != null)
                {
                    if(player.handObject != null)
                    {
                        player.handObject.Reactor = null;
                    }
                }
                FindObjectOfType<AudioManager>().Play("R�j�hdys");
                shake.CamShake();
                active = false;
                Instantiate(effect, transform.position, Quaternion.identity);
                DayTime.reactorsDestoyed++;
                DifficultyIncrease();
            }
        }
    }
    void DifficultyIncrease()
    {
        Reactor[] reactors = FindObjectsOfType<Reactor>();
        foreach (Reactor reactor in reactors)
        {
            reactor.ChangeDifficulty(1);
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
        if (collision.CompareTag("Player") && active)
        {
            player = collision.GetComponent<PlayerMovement>();
            if (player.handObject != null)
            {
                player.handObject.Reactor = this;
                if (firstTime == true && TutorialText.index == 3)
                {
                    TutorialText.NextLine();
                    firstTime = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && active)
        {
            if (player != null)
            {
                if (player.handObject != null)
                {
                    player.handObject.Reactor = null;
                }
            }
        }
    }

    public void Activate()
    {
        active = true;
    }
    public void ChangeDifficulty(int newDifficulty)
    {
        difficulty += newDifficulty;
    }
    public void ChangeBaseSpeed(int newDifficulty)
    {
        baseTime = newDifficulty;
    }
}
