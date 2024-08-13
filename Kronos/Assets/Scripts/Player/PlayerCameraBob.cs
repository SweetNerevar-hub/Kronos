using UnityEngine;

public class PlayerCameraBob : MonoBehaviour
{
    [SerializeField] private float m_amplitude;
    [SerializeField] private float m_frequency;
    [SerializeField] private float m_smoothing;
    [SerializeField] private float m_resetSpeed;

    private Vector3 m_startPos;

    private void Start()
    {
        m_startPos = transform.localPosition;
    }

    public void Headbob(float moveSpeedMultiplier)
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * m_frequency * moveSpeedMultiplier) * m_amplitude * 1.4f * moveSpeedMultiplier, m_smoothing * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * m_frequency * moveSpeedMultiplier / 2f) * m_amplitude * 1.6f * moveSpeedMultiplier, m_smoothing * Time.deltaTime);
        transform.localPosition += pos;
    }

    public void ResetHeadbob()
    {
        if (transform.localPosition == m_startPos)
        {
            return;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, m_startPos, m_resetSpeed * Time.deltaTime);
    }
}
