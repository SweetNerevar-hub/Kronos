using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDelay : MonoBehaviour
{
    public int seconds;
    public GameObject objectToDelay;

    private bool triggered = false;
    private bool barkDone;
    // Start is called before the first frame update
    void Start()
    {
        barkDone = DialogueLua.GetVariable("barksDone").AsBool;
        StartCoroutine(WaitForEnable());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (barkDone && triggered)
        {
            StartCoroutine(WaitForRestart());
        }
    }

    private IEnumerator WaitForEnable()
    {
        triggered = true;
        yield return new WaitForSeconds(seconds);
        objectToDelay.SetActive(true);
    }

    private IEnumerator WaitForRestart()
    {
        triggered = false;
        objectToDelay.SetActive(false);
        int waitTime = Random.Range(10, 15);
        yield return new WaitForSeconds(waitTime);
        objectToDelay.SetActive(true);
        DialogueLua.SetVariable("barksDone", false);
    }


}
