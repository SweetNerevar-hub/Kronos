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

    [SerializeField] private AudioClip m_doorOpenAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void TimeTravel()
    {
        SFXManager.s_isBackInTime = true;
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
        SFXManager.Instance.PlayAudio(m_doorOpenAudio);

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
