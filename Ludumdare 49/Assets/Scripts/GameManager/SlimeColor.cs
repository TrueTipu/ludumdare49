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
            Debug.Log(slimes);
            if(slimes > 0)
            {
                image.color = new Color(1, 1, 1, (image.color.a + (speed * slimes)));
            }
            else if (image.color.a > 0)
            {
                image.color = new Color(1, 1, 1, (image.color.a - speed * 2));
            }
            yield return new WaitForSeconds(0.5f);
            if(image.color.a > 0.99f)
            {
                DayTime.ready = true;
            }
        }
    }
}
