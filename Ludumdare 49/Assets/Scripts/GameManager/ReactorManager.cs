using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ReactorManager : MonoBehaviour
{
    [SerializeField]
    List<Reactor.ReactorData> reactorDatas;

    [System.Serializable]
    class ReactorEvent
    {
        public float time;
        public UnityEvent action;
    }

    [SerializeField]
    List<ReactorEvent> eventDatas;

    float waitTime;
    float timer;
    int currentEvent = 0;
    private void Awake()
    {
        for (int i = 0; i < reactorDatas.Count; i++)
        {
            reactorDatas[i].reactor.SetData(reactorDatas[i]);
        }

        NextEvent(-1);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            NextEvent(currentEvent);
        }
    }

    void NextEvent(int eventIndex)
    {
        if(eventIndex >= 0 && eventIndex < eventDatas.Count)
        {
            eventDatas[eventIndex].action.Invoke();
        }

        timer = 0;
        currentEvent = eventIndex + 1;
        if (eventIndex < eventDatas.Count)
        {
            waitTime = eventDatas[currentEvent].time;
        }
    }

    public void Log1()
    {
        Debug.Log(1);
    }
    public void Log2()
    {
        Debug.Log(2);
    }
    public void Log3()
    {
        Debug.Log(3);
    }
}
