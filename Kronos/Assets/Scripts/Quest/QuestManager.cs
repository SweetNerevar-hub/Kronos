using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [SerializeField] private Quest[] m_allQuests;
    [SerializeField] private List<Quest> currentQuests = new List<Quest>();

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }

    public void StartQuest(Quest quest)
    {
        currentQuests.Add(quest);
        quest.OnStartQuest();
        print($"You started the quest: {quest.GetQuestName()}");
    }

    public void FinishQuest(Quest quest)
    {
        for (int i = 0; i < currentQuests.Count; i++)
        {
            if (currentQuests[i].GetQuestName() == quest.GetQuestName())
            {
                currentQuests[i].OnCompleteQuest();
                currentQuests.RemoveAt(i);
                print($"You finished the quest: {quest.GetQuestName()}");
                return;
            }
        }
    }
}
