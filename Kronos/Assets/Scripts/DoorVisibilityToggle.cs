using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DoorVisibilityToggle : MonoBehaviour
{
    public bool inactiveOnStart;

    // Start is called before the first frame update
    void Start()
    {
        if (inactiveOnStart)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
