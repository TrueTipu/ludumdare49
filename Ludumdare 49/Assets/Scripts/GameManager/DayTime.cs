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

    [SerializeField]
    Image GameOver;

    [SerializeField]
    public static int reactorsDestoyed;

    public static bool ready;

    void Awake()
    {
        reactorsDestoyed = 0;
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        while(true)
        {
            if(reactorsDestoyed > 1 || ready)
            {
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            }
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
