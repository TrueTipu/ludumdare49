using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorManager : MonoBehaviour
{
    [SerializeField]
    List<Reactor.ReactorData> reactorDatas;

    private void Awake()
    {
        for (int i = 0; i < reactorDatas.Count; i++)
        {
            reactorDatas[i].reactor.SetData(reactorDatas[i]);
        }
    }

}
