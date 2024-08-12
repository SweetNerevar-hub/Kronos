using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestUsableActivation : MonoBehaviour
{
    public GameObject[] questNPC;
    private bool triggeredStart;
    private bool triggeredEnd;

    private QuestState questState;
    private string questName = "The Missing Envelope";
    // Start is called before the first frame update
    void Start()
    {
        questState = QuestLog.GetQuestState(questName);
        Debug.Log("the quest: " + questName + " is " + questState.ToString());
        DisableUsables();
        
    }

    // Update is called once per frame
    void Update()
    {
        QuestState currentQuestState = QuestLog.GetQuestState(questName);
        if (currentQuestState == QuestState.Active && !triggeredStart)
        {
            EnableUsables();
            triggeredStart = true;
        }

        if (currentQuestState == QuestState.Success && !triggeredEnd)
        {
            triggeredEnd = true;
            DisableUsables();
        }
    }

    public void EnableUsables()
    {
        foreach (var npc in questNPC)
        {
            Usable usable = npc.GetComponent<Usable>();
            if (usable != null)
            {
                usable.enabled = true;
                Debug.Log("Usable component for " + npc.name + "has been enabled");
            }

        }
    }

    public void DisableUsables()
    {

        foreach (var npc in questNPC)
        {
            Usable usable = npc.GetComponent<Usable>();
            if (usable != null)
            {
                usable.enabled = false;
                Debug.Log("Usable component for " + npc.name + "has been disabled");
            }

        }
        
    }
}
