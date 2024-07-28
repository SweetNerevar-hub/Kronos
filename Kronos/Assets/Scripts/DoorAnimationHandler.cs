using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationHandler : MonoBehaviour
{
    private Animator anim;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !doorOpen)
        {
            anim.SetBool("character_nearby", true);
            doorOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.L) && doorOpen)
        {
            anim.SetBool("character_nearby", false);
            doorOpen = false;
        }
    }
}
