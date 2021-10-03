using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShake : MonoBehaviour
{
    public Animator camAnim;

    public void CamShake()
    {
        Debug.Log("burh");
        camAnim.SetTrigger("shake");
    }
}