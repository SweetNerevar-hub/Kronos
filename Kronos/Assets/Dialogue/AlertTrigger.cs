using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AlertTrigger : MonoBehaviour
{

    private bool hasBeenTriggered = false;

    public string alertText;
    public bool triggerInPast;
    private bool isPast;

    private void Start()
    {
        isPast = DialogueLua.GetVariable("BackInTime").AsBool;
    }

    private void OnTriggerEnter(Collider other)
    {
        isPast = DialogueLua.GetVariable("BackInTime").AsBool;
        if (isPast)
        {
            if (triggerInPast)
            {
                if (other.CompareTag("Player") && !hasBeenTriggered)
                {
                    hasBeenTriggered = true;
                    DialogueManager.ShowAlert(alertText, 3);
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            if (other.CompareTag("Player") && !hasBeenTriggered)
            {
                hasBeenTriggered = true;
                DialogueManager.ShowAlert(alertText, 3);
            }
        }
    }

}
