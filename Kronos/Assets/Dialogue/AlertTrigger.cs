using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AlertTrigger : MonoBehaviour
{

    private bool hasBeenTriggered = false;

    public string alertText;

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            hasBeenTriggered = true;
            DialogueManager.ShowAlert(alertText, 3);
        } 
    }

}
