using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShake : MonoBehaviour
{
    [SerializeField]
    Animator camAnim;

    public void CamShake()
    {
        Debug.Log("burh");
        camAnim.SetTrigger("shake");
    }
}