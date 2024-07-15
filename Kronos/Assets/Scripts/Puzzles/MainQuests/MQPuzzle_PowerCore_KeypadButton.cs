using UnityEngine;

public class MQPuzzle_PowerCore_KeypadButton : MonoBehaviour, IInteractable
{
    [SerializeField] private MQPuzzle_PowerCore_Core m_core;
    [SerializeField] private int m_keyCode;

    public void Interact()
    {
        m_core.KeypadInput(m_keyCode);
    }
}
