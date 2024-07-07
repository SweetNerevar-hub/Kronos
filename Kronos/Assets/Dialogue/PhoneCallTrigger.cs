using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class PhoneCallTrigger : MonoBehaviour
{

    private BoxCollider bx;
    public int seconds;

    public AudioSource ringing;

    private bool restarted;

    private bool ignoredCaptain;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForPhonecall());
        bx = GetComponent<BoxCollider>();
        bx.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (ignoredCaptain && !restarted)
        {
            restarted = true;
            bx.enabled = false;
            StartCoroutine(WaitForPhonecall());
        }
    }

    private IEnumerator WaitForPhonecall()
    {
        yield return new WaitForSeconds(seconds);
        bx.enabled = true;
        ringing.Play();
    }

    
}
