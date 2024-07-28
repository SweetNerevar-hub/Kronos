using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Runtime.CompilerServices;

public class DoorVisibilityToggle : MonoBehaviour
{
    public bool inactiveInPresent;
    private bool isPast;
    private Usable usable;

    // Start is called before the first frame update
    void Start()
    {
        usable = GetComponent<Usable>();
        isPast = DialogueLua.GetVariable("BackInTime").asBool;

        if (inactiveInPresent && !isPast)
        {
            usable.enabled = false;
        }
        else if (inactiveInPresent && isPast)
        {
            usable.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
