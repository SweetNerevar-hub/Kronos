using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject startMenu;
    public GameObject newGameMenu;
    public GameObject settingsMenu;
    public GameObject audioSettings;



    //NOTE: 'MM' is for buttons on the Main Menu, 'NGM' is for buttons on the New Game Menu, and 
    //      'SM' is for buttons on the Settings Menu.
    private void Start()
    {
        Time.timeScale = 1.0f;
    }


    //--------------------------------------------------------
    public void MM_startGame()
    {
        audioSource.PlayOneShot(audioClip);
        SceneManager.LoadScene(sceneName);
        //Debug.Log("clicked");
    }

    public void MM_newGame()
    {
        audioSource.PlayOneShot(audioClip);
        newGameMenu.SetActive(true);
        startMenu.SetActive(false);
        Debug.Log("new game");
    }

    public void MM_goToSettings()
    {
        audioSource.PlayOneShot(audioClip);
        settingsMenu.SetActive(true);
        startMenu.SetActive(false);
        Debug.Log("go to settings");
    }

    public void MM_exitGame()
    {
        audioSource.PlayOneShot(audioClip);
        Application.Quit();
        Debug.Log("quit");
    }

    public void NGM_backButtonPressed()
    {
        audioSource.PlayOneShot(audioClip);
        newGameMenu.SetActive(false);
        settingsMenu.SetActive(false);
        startMenu.SetActive(true);
        Debug.Log("back button pressed");
    }

    public void NGM_slotButtonPressed()
    {
        audioSource.PlayOneShot(audioClip);
        Debug.Log("new slot");
    }

    public void SM_backButton()
    {
        audioSource.PlayOneShot(audioClip);
        audioSettings.SetActive(false);
        settingsMenu.SetActive(true);
        Debug.Log("back button pressed");
    }
    
    public void SM_goToAudioSettings()
    {
        audioSource.PlayOneShot(audioClip);
        audioSettings.SetActive(true);
        settingsMenu.SetActive(false);
        Debug.Log("go to audio settings");
    }
}
