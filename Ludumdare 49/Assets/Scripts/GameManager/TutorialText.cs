using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public List<string> lines;

    public static int index = 0; 
    [SerializeField]
    TextMeshProUGUI text;

    static TutorialText instance;

    private void Start()
    {
        instance = this;
        text.text = lines[index];
    }

    public static void NextLine()
    {
        instance.ChangeLine();       
    }
    void ChangeLine()
    {
        index++;
        text.text = lines[index];
    }

}
