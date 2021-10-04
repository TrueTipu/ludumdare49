using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour, IHandObject
{
    [SerializeField]
    Animator animator;
    public bool firstTime = false;

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

    public void UseObject(bool turha)
    {
        if(Slime != null)
        {
            animator.SetTrigger("Kaiva");
            //Debug.Log("tyhäj");
            Slime.Fix();
            FindObjectOfType<AudioManager>().Play("Lapio");
            if (firstTime == true)
            {
                TutorialText.NextLine();
                firstTime = false;
            }
        }
    }
}
