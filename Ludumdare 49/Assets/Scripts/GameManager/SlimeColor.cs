using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeColor : MonoBehaviour
{
    int slimes;

    public float speed;

    [SerializeField]
    Image image;

    private void Start()
    {
        StartCoroutine(colorCheck());
    }

    IEnumerator colorCheck()
    {
        while(true)
        {
            slimes = FindObjectsOfType<Slime>().Length;
            if(slimes > 0)
            {
                image.color = new Color(255, 255, 255, (image.color.a + (speed * slimes)));
            }
            else
            {
                image.color = new Color(255, 255, 255, (image.color.a - speed));
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
