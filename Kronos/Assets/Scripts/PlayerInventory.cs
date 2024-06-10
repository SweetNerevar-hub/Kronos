using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<string> m_inventory = new List<string>();

    public void AddToInventory(string itemName)
    {
        m_inventory.Add(itemName);
        print($"{itemName} added to inventory");
    }

    public void RemoveFromInventory(string itemName)
    {
        for (int i = 0; i < m_inventory.Count; i++)
        {
            if (m_inventory[i] == itemName)
            {
                m_inventory.RemoveAt(i);
                print($"{itemName} removed from inventory");
                return;
            }
        }
    }

    public List<string> GetPlayerInventory() => m_inventory;
}
