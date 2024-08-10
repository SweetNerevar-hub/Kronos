using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyboxController : MonoBehaviour
{
    public Material mainSkybox;
    public Material backInTimeSkybox;
    private string currentSceneName;
    private bool inPast;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        inPast = DialogueLua.GetVariable("BackInTime").asBool;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSceneName == "Festival Area" || inPast)
        {
            RenderSettings.skybox = backInTimeSkybox;
        }
        else
        {
            RenderSettings.skybox = mainSkybox;
        }
    }
}
