using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class LUATesting : MonoBehaviour
{
    private string questName = "TEST";
    private int currentEntry = 1;
    private int totalEntries = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.T))
        {
            QuestLog.SetQuestState(questName, QuestState.Active);
            QuestLog.SetQuestEntryState(questName, 1, QuestState.Active);
            currentEntry = 1;
            Debug.Log("test quest is active and task1 is active");
        }

       if (Input.GetKeyDown(KeyCode.P))
        {
            AdvanceQuestEntry();
        }
    }

    private void AdvanceQuestEntry()
    {
        if (currentEntry <= totalEntries)
        {
            // Set current task to success
            QuestLog.SetQuestEntryState(questName, currentEntry, QuestState.Success);
            Debug.Log($"task{currentEntry} set to success.");

            // Move to the next task if it exists
            currentEntry++;
            if (currentEntry <= totalEntries)
            {
                QuestLog.SetQuestEntryState(questName, currentEntry, QuestState.Active);
                Debug.Log($"task{currentEntry} set to active.");
            }
            else
            {
                // All tasks are completed, set the whole quest to success
                QuestLog.SetQuestState(questName, QuestState.Success);
                Debug.Log("All tasks completed. Quest set to success.");
            }
        }
    }


}
