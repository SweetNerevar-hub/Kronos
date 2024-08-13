using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MQPuzzle_Battery_Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MQPuzzle_Battery m_battery;
    private RawImage m_buttonImage;

    [SerializeField] private bool m_isGreen;
    [SerializeField] private bool m_isCircuitConnector;
    [SerializeField] private int m_batteryArrayIndex;

    public bool IsGreen
    {
        get { return m_isGreen; }
    }

    public bool IsCircuitConnecter
    {
        get { return m_isCircuitConnector; }
    }

    private void Awake()
    {
        m_buttonImage = GetComponent<RawImage>();
    }

    public void ToggleButton(bool wasCircuitConnector)
    {
        if (!wasCircuitConnector)
        {
            m_isGreen = !m_isGreen;
        }
        
        m_buttonImage.color = (m_isGreen) ? Color.green : Color.red;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && !m_isCircuitConnector)
        {
            ToggleButton(m_isCircuitConnector);
            m_battery.ToggleAdjacentButtons(m_batteryArrayIndex);
        }

        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!m_isCircuitConnector && m_battery.CircuitConnectersPlaced < 2)
            {
                m_battery.CircuitConnectersPlaced++;

                m_buttonImage.color = Color.grey;
                m_isCircuitConnector = true;
            }

            else if (m_isCircuitConnector)
            {
                m_battery.CircuitConnectersPlaced--;

                ToggleButton(m_isCircuitConnector);
                m_isCircuitConnector = false;
            }
        }

        m_battery.CheckForWinCondition();
    }
}
