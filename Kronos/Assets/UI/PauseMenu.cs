using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public GameObject HUD;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //---> for pausing with ESC
        {
            audioSource.PlayOneShot(audioClip);
            pauseMenu.SetActive(true);
            Debug.Log("paused");
            HUD.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Pause()   //---> for pausing with button
    {
         pauseMenu.SetActive(true);
         HUD.SetActive(false);
         Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ReturnToSettings(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        Debug.Log("go to settings");
    }

    public void QuitToMenu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void OnApplicationQuit()
    {
        //Application.Quit();
        Debug.Log("quit");
    }

}
