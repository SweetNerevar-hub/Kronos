using UnityEngine;

public enum QUEST_TYPE { FETCH }

[CreateAssetMenu(menuName = "New Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string m_questName;
    [SerializeField] private QUEST_TYPE m_questType;
    [SerializeField] private bool m_isActive;
    [SerializeField] private bool m_isCompleted;

    [field: Header("Only put in what is relevant to the quest type")]
    [field: SerializeField] public QuestItem QuestItem { get; private set; }

    public void OnStartQuest()
    {
        m_isActive = true;
    }

    public void OnCompleteQuest()
    {
        m_isCompleted = true;
        m_isActive = false;
    }

    public string GetQuestName() => m_questName;

    public bool IsActive() => m_isActive;

    public bool IsCompleted() => m_isCompleted;

    public QUEST_TYPE GetQuestType() => m_questType;
}
