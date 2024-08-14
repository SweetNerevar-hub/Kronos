using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AlertArrayTrigger : MonoBehaviour
{
    public string[] alertArray;
    private int currentAlertIndex = 0;
    private bool isTriggerActive = false;

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
                if (other.CompareTag("Player") && !isTriggerActive)
                {
                    isTriggerActive = true;
                    StartCoroutine(ShowAlerts());
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            if (other.CompareTag("Player") && !isTriggerActive)
            {
                isTriggerActive = true;
                StartCoroutine(ShowAlerts());
            }
        }
        
    }

    private IEnumerator ShowAlerts()
    {
        while (currentAlertIndex < alertArray.Length)
        {
            DialogueManager.ShowAlert(alertArray[currentAlertIndex], 3);
            currentAlertIndex++;
            yield return new WaitForSeconds(3);
        }
        isTriggerActive = false;
}
}
