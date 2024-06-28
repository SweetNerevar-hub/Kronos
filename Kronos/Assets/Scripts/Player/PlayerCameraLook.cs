using UnityEngine;

public class PlayerCameraLook : MonoBehaviour
{
    [SerializeField] private float m_sensitivity;

    private Transform m_player;
    private float m_pitch;
    private float m_yaw;
    private const int m_clampAmount = 80;

    public bool inConversation; //to tell the script when we're in conversation - George

    private void Start()
    {
        m_player = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inConversation = false;
    }

    private void Update()
    {
        if (!inConversation) //added so I can control this from the two functions I made below - George
        {
            m_pitch += Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
            m_yaw += Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;

            SetCameraClamp();

            transform.localRotation = Quaternion.Euler(-m_yaw, 0f, 0f);
            m_player.rotation = Quaternion.Euler(0f, m_pitch, 0f);
        }
    }

    private void SetCameraClamp()
    {
        if (m_yaw > m_clampAmount)
        {
            m_yaw = m_clampAmount;
        }

        else if (m_yaw < -m_clampAmount)
        {
            m_yaw = -m_clampAmount;
        }
    }

    public void ConversationStart() //added so I can pause looking around when conversation starts - George
    {
        inConversation = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ConversationEnd()
    {
        inConversation = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
