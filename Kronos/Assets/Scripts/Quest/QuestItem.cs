using UnityEngine;

public class QuestItem : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string ItemName { get; private set; }

    private PlayerInventory m_playerInventory;

    private void Start()
    {
        m_playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void Interact()
    {
        m_playerInventory.AddToInventory(ItemName);
        Destroy(gameObject);
    }
}
