using UnityEngine;

public class NPCQuestGiver : MonoBehaviour, IInteractable
{
    [SerializeField] private Quest m_quest;

    private PlayerInventory m_playerInventory;

    private void Start()
    {
        m_playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void Interact()
    {
        if (m_quest)
        {
            CheckQuestStatus();
        }
    }

    private void CheckQuestStatus()
    {
        if (m_quest.IsCompleted())
        {
            print("You've already completed that quest");
            return;
        }

        if (!m_quest.IsActive() && !m_quest.IsCompleted())
        {
            QuestManager.Instance.StartQuest(m_quest);
        }

        else if (m_quest.IsActive())
        {
            // ask the player how the quest is going

            if (m_quest.GetQuestType() == QUEST_TYPE.FETCH)
            {
                if (m_playerInventory.GetPlayerInventory().Contains(m_quest.QuestItem.ItemName))
                {
                    m_playerInventory.RemoveFromInventory(m_quest.QuestItem.ItemName);
                    // thanks the player for completing their quest
                    // maybe there's a follow-up quest
                    QuestManager.Instance.FinishQuest(m_quest);
                    return;
                }

                // might give the player directions as to how to find the quest item
            }
        }
    }
}
