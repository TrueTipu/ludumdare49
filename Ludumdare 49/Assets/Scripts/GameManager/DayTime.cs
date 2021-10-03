using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayTime : MonoBehaviour
{

    public float daytime;
    float timer;

    [SerializeField]
    Image moon;
    [SerializeField]
    Image sun;


    void Awake()
    {
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        while(true)
        {
            timer += 0.2f;
            moon.fillAmount = timer / daytime;
            sun.fillAmount = 1 - timer / daytime;
            yield return new WaitForSeconds(0.2f);
            if(timer > daytime)
            {
                break;
            }
        }
    }
}
