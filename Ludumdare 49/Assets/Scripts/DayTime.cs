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
    Image bc;


    void Awake()
    {
        SetPositionAndScale();
    }

    void SetPositionAndScale()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        moon.fillAmount = timer / daytime;
        bc.fillAmount = timer / daytime;
    }
}
