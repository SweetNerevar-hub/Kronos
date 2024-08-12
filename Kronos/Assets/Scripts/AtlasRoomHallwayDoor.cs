using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class AtlasRoomHallwayDoor : MonoBehaviour
{
    private bool isPast;

    public GameObject presentDoor;
    public GameObject pastDoor;

    // Start is called before the first frame update
    void Start()
    {
        isPast = DialogueLua.GetVariable("BackInTime").asBool;

        if (isPast)
        {
            presentDoor.SetActive(false);
            pastDoor.SetActive(true);
        }
        else
        {
            presentDoor.SetActive(true);
            pastDoor.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
