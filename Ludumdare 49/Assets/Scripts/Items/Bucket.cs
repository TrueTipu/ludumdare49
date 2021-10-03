using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour, IHandObject
{
    [SerializeField]
    Animator animator;


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

    public IFixableThing FixableThing { get; set; }

    public bool firstTime = false;

    public void UseObject(bool river)
    {
        bool reactor = false;
        if(FixableThing != null)
        {
            reactor = (FixableThing.GetType() == typeof(Reactor));
        }
        if(reactor && Active)
        {
            Active = false;
            animator.SetBool("Vesi", false);
            Debug.Log("tyhäj");
            FixableThing.Fix();
            FindObjectOfType<AudioManager>().Play("Vesi heitto");
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
            animator.SetBool("Vesi", true);
            FindObjectOfType<AudioManager>().Play("Vesi keruu");
            if (firstTime == true)
            {
                TutorialText.NextLine();
            }
        }
    }
    

}
