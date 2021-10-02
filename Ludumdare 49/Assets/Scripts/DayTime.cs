using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{

    public float daytime;
    float timer;

    [SerializeField]
    Transform childSlider;

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
        childSlider.localScale = new Vector2(timer / daytime, 1);
    }
}
