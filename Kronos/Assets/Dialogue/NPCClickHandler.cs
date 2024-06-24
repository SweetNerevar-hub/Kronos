using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCClickHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        var trigger = GetComponent<DialogueSystemTrigger>();
        if (trigger != null)
        {
            trigger.OnUse();
        }
    }
}
