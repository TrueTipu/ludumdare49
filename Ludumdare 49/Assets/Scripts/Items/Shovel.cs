using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour, IHandObject
{
    [SerializeField]
    Animator animator;


    private string objectName = "Shovel";

    public string ObjectName
    {
        get { return objectName; }
        set { objectName = value; }
    }

    public bool Active { get; set; }


    public IFixableThing FixableThing { get; set; }

    public bool firstTime = false;

    public void UseObject(bool turha)
    {
        bool slime;
        slime = (FixableThing.GetType() == typeof(Slime));
        if(slime && Active)
        {
            Active = false;
            //animator.SetBool("Vesi", false);
            //Debug.Log("tyhäj");
            FixableThing.Fix();
            //FindObjectOfType<AudioManager>().Play("Vesi heitto");
            if (firstTime == true)
            {
                TutorialText.NextLine();
                firstTime = false;
            }
        }
    }
    

}
