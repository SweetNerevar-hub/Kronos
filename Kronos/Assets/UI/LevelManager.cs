using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
        //Debug.Log("clicked");
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
