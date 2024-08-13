using UnityEngine;
using UnityEngine.EventSystems;

public class MQPuzzle_PowerCore_KeypadButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MQPuzzle_PowerCore_Core m_core;
    [SerializeField] private int m_keyCode;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_core.KeypadInput(m_keyCode);
    }
}
