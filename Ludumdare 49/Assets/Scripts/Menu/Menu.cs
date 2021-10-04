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
        dayAnim.SetTrigger("end");
        yield return null;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

}