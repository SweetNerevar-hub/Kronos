using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AlertTrigger : MonoBehaviour
{

    private bool hasBeenTriggered = false;

    public string alertText;
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
       if (other.CompareTag("Player") && !hasBeenTriggered)
        {
            hasBeenTriggered = true;
            DialogueManager.ShowAlert(alertText, 3);
        } 
    }
}
