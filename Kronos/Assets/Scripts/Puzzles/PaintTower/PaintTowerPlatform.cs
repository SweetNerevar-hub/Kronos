using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;

public class PaintTowerPlatform : MonoBehaviour
{
    private List<PaintCan> m_cans = new List<PaintCan>(3);

    [SerializeField] private bool m_isFinalPlatform;

    private void Update()
    {
        if (m_isFinalPlatform && m_cans.Count == 3)
        {
            bool correctOrder = m_cans[0].CanSize == CanSize.Large && m_cans[1].CanSize == CanSize.Medium && m_cans[2].CanSize == CanSize.Small;

            if (correctOrder)
            {
                foreach (PaintCan can in m_cans)
                {
                    if (can.IsHeld())
                    {
                        return;
                    }
                }

                print("YOU COMPLETED THE PUZZLE!");
                DialogueLua.SetVariable("TowerOfPaint.IsCompleted", true);
                m_cans.Clear();
            }
        }

        if (m_cans.Count > 0)
        {
            SetValidPickUp();
        }
    }

    private void SetValidPickUp()
    {
        int lastIndex = m_cans.Count - 1;

        for (int i = 0; i < m_cans.Count; i++)
        {
            if (i == lastIndex)
            {
                m_cans[i].SetPickupFlag(true);
                break;
            }

            m_cans[i].SetPickupFlag(false);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.TryGetComponent(out PaintCan can))
        {
            m_cans.Add(can);
            can.SetInBoundsFlag(true);
            can.SetBoundsPosition(new Vector3(transform.position.x, can.transform.position.y, transform.position.z));
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.TryGetComponent(out PaintCan can))
        {
            m_cans.Remove(can);
            can.SetInBoundsFlag(false);
        }
    }
}
