using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject DialogueUI;
    public GameObject HUD;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject settingsMenu;

    public bool isPaused = false;

    private ToggleCursor toggleCursor;

    public bool inConversation = false;

    private void Start()
    {
        toggleCursor = GetComponentInParent<ToggleCursor>();
        DialogueUI = GameObject.Find("DialogueUI");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //---> for pausing with ESC
        {
            if (!isPaused)
            {
                audioSource.PlayOneShot(audioClip);
                pauseMenu.SetActive(true);
                DialogueUI.SetActive(false);
                Debug.Log("paused");
                HUD.SetActive(false);
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                audioSource.PlayOneShot(audioClip);
                Resume();
            }
        }
        
    }

    public void InConversation()
    {
        inConversation = true;
    }
    public void EndConversation()
    {
        inConversation = false;
    }
    /*public void Pause()   //---> for pausing with button
    {
         pauseMenu.SetActive(true);
         HUD.SetActive(false);
         Time.timeScale = 0f;
    }*/

    public void Resume()
    {
        Debug.Log("Resumed");
        pauseMenu.SetActive(false);
        if (!inConversation)
        {
            HUD.SetActive(true);
            toggleCursor.HideCursorAfterPause();
            Time.timeScale = 1f;
        }

        DialogueUI.SetActive(true);        
        isPaused = false;
    }

    public void ReturnToSettings(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        audioSource.PlayOneShot(audioClip);
        //settingsMenu.SetActive(true);
        Debug.Log("go to settings");
    }

    public void QuitToMenu(int sceneID)
    {
        DialogueUI.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        isPaused = false;
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
