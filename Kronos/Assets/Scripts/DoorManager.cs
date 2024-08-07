using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DoorManager : MonoBehaviour
{
    private Animator anim;
    public ScenePortal scenePortal;

    public bool playAnimations;

    public AudioSource LASTsound;

   
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeTravel()
    {
        StartCoroutine(WaitForTimeTravel());
    }

    private IEnumerator WaitForTimeTravel()
    {
        LASTsound.Play();
        yield return new WaitForSeconds(5);
        scenePortal.UsePortal();
    }

    public void DoorInteraction()
    {
        if (playAnimations)
        {
            anim.SetBool("character_nearby", true);
            StartCoroutine(DoorFunction());  
        }
        else
        {
            scenePortal.UsePortal();
        }
        
    }

    private IEnumerator DoorFunction()
    {
        yield return new WaitForSeconds(0.5f);
        scenePortal.UsePortal();
    }

    
}
