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

    public bool Active { get; set; }

    public void ChargeObject()
    {
        if(Active == false)
        {
            Active = true;
            Debug.Log("täyn");
        }
    }

    public Reactor Reactor { get; set; }

    public bool firstTime = false;

    public void UseObject(bool river)
    {
        if(Reactor != null && Active)
        {
            Active = false;
            Debug.Log("tyhäj");
            Reactor.Fix();

            if (firstTime == true)
            {
                TutorialText.NextLine();
                firstTime = false;
            }
        }
        if(river && !Active)
        {
            Active = true;
            Debug.Log("täyh");

            if (firstTime == true)
            {
                TutorialText.NextLine();
            }
        }
    }
    

}
