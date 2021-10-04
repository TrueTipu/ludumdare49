using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator dayAnim;


    public void PlayGame()
    {
        StartCoroutine(LoadScene(1));
    }

    public void Reload()
    {
        StartCoroutine(LoadScene(0));
    }

    IEnumerator LoadScene(int index)
    {
        Time.timeScale = 1;
        DayTime.reactorsDestoyed = 0;
        DayTime.ready = false;
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

}