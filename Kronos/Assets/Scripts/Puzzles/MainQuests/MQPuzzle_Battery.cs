using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class MQPuzzle_Battery : MonoBehaviour, IInteractable
{
    [SerializeField] private ToggleCursor m_toggleCursor;
    [SerializeField] private PuzzleManager m_puzzleManager;
    [SerializeField] private RawImage m_batteryPanelImage;
    [SerializeField] private MQPuzzle_Battery_Button[] m_buttons;

    [SerializeField] private int m_circuitConnectorsPlaced;
    [SerializeField] private AudioClip m_puzzleCompleted;

    [SerializeField] private GameObject toolBox;
    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private Usable batteryUsable;

    private const int c_adjacentButtonBuffer = 4;

    private bool m_isFixed = false;

    public int CircuitConnectersPlaced
    {
        get { return m_circuitConnectorsPlaced; }
        set { m_circuitConnectorsPlaced = value; }
    }

    private void Start()
    {
        if (!m_isFixed)
        {
            m_batteryPanelImage.gameObject.SetActive(true);
            RandomlyAssignButtonStatus();
            m_batteryPanelImage.gameObject.SetActive(false);
        }
    }

    private void RandomlyAssignButtonStatus()
    {
        int maxAssigns = 8;

        for (int i = 0; i < m_buttons.Length; i++)
        {
            int r = Random.Range(0, 10);

            if (r >= 7 && maxAssigns > 0)
            {
                maxAssigns--;
                m_buttons[i].ToggleButton(false);
            }
        }
    }

    public void Interact()
    {
        if (m_isFixed)
        {
            return;
        }

        m_batteryPanelImage.gameObject.SetActive(true);
        m_puzzleManager.DisablePlayerControl();
        m_toggleCursor.ToggleCursorState(true);
        batteryUsable.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && m_batteryPanelImage.IsActive())
        {
            m_batteryPanelImage.gameObject.SetActive(false);
            m_puzzleManager.EnablePlayerControl();
            m_toggleCursor.ToggleCursorState(false);
            batteryUsable.enabled = true;
        }
    }

    public void ToggleAdjacentButtons(int index)
    {
        if (index - 1 >= 0 && !m_buttons[index - 1].IsCircuitConnecter)
        {
            m_buttons[index - 1].ToggleButton(false);
        }

        if (index + 1 <= m_buttons.Length - 1 && !m_buttons[index + 1].IsCircuitConnecter)
        {
            m_buttons[index + 1].ToggleButton(false);
        }

        if (index - c_adjacentButtonBuffer >= 0 && !m_buttons[index - c_adjacentButtonBuffer].IsCircuitConnecter)
        {
            m_buttons[index - c_adjacentButtonBuffer].ToggleButton(false);
        }

        if (index + c_adjacentButtonBuffer <= m_buttons.Length - 1 && !m_buttons[index + c_adjacentButtonBuffer].IsCircuitConnecter)
        {
            m_buttons[index + c_adjacentButtonBuffer].ToggleButton(false);
        }
    }

    public void CheckForWinCondition()
    {
        for (int i = 0; i < m_buttons.Length; i++)
        {
            if (!m_buttons[i].IsGreen && !m_buttons[i].IsCircuitConnecter)
            {
                return;
            }
        }

        OnComplete();
    }

    private void OnComplete()
    {
        m_isFixed = true;
        toolBox.SetActive(false);
        sparks.Stop();
        batteryUsable.enabled = false;

        SFXManager.Instance.PlayAudio(m_puzzleCompleted);

        m_batteryPanelImage.gameObject.SetActive(false);
        m_puzzleManager.EnablePlayerControl();
        m_puzzleManager.IncreaseBatteryCompletionCount();
        m_toggleCursor.ToggleCursorState(false);
    }
}
