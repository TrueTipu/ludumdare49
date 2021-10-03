using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakasMenuun : MonoBehaviour
{
    public Animator dayAnim;
    public string sceneName;
    public void PlayGame()
    {
        StartCoroutine(LoadaaScene());
    }

    IEnumerator LoadaaScene()
    {
        dayAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

}