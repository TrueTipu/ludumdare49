using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour, IHandObject
{
    [SerializeField]
    Animator animator;

    public GameObject GameObject
    {
        get { return this.gameObject; }
        set { GameObject = value; }
    }
    private string objectName = "Shovel";

    public string ObjectName
    {
        get { return objectName; }
        set { objectName = value; }
    }

    public bool Active { get; set; }


    public Reactor Reactor { get; set; }
    public Slime Slime { get; set; }

    public bool firstTime = false;

    public void UseObject(bool turha)
    {
        if(Slime != null)
        {
            //animator.SetBool("Vesi", false);
            //Debug.Log("tyhäj");
            Slime.Fix();
            //FindObjectOfType<AudioManager>().Play("Vesi heitto");
            if (firstTime == true)
            {
                TutorialText.NextLine();
                firstTime = false;
            }
        }
    }
}
