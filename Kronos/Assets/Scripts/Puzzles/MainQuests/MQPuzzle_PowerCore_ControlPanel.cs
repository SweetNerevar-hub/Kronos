using UnityEngine;

public class MQPuzzle_PowerCore_ControlPanel : MonoBehaviour, IInteractable
{
    [SerializeField] private MQPuzzle_PowerCore_Core m_core;
    [SerializeField] private PuzzleManager m_puzzleManager;
    [SerializeField] private ToggleCursor m_toggleCursor;
    [SerializeField] private GameObject m_controlPanelImage;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && m_controlPanelImage.activeInHierarchy)
        {
            DoOpenControlPanel(false);
        }
    }

    public void Interact()
    {
        // If the player isn't supposed to fix the power core yet
        /*if ()
        {
            // Dialogue that gives context as to why the player can't fix the power core yet
            return;
        }*/

        if (m_core.IsCompleted)
        {
            // The power core is already on
            return;
        }

        if (!m_controlPanelImage.activeInHierarchy)
        {
            DoOpenControlPanel(true);
        }
    }

    public void DoOpenControlPanel(bool toggle)
    {
        if (toggle)
        {
            m_controlPanelImage.SetActive(true);
            m_puzzleManager.DisablePlayerControl();
            m_toggleCursor.ToggleCursorState(true);
            return;
        }

        m_controlPanelImage.SetActive(false);
        m_puzzleManager.EnablePlayerControl();
        m_toggleCursor.ToggleCursorState(false);
    }
}
