using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string sceneName;

    private void Start()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}