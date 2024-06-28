using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AlertArrayTrigger : MonoBehaviour
{
    public string[] alertArray;
    private int currentAlertIndex = 0;
    private bool isTriggerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggerActive)
        {
            isTriggerActive = true;
            StartCoroutine(ShowAlerts());
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
