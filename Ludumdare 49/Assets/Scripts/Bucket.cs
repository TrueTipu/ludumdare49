using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour, IHandObject
{

    private string objectName = "Bucket";

    public string ObjectName
    {
        get { return objectName; }
        set { objectName = value; }
    }

    public void PickUp()
    {

    }
}
