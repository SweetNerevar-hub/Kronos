using UnityEngine;

public class PlayerCameraLook : MonoBehaviour
{
    private static float m_sensitivity = 50f;

    private Transform m_player;
    private float m_pitch;
    private float m_yaw;
    private const int m_clampAmount = 80;


    private void Start()
    {
        m_player = transform.parent;

    }

    private void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            AdjustCameraSensitivity(1);
        }

        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            AdjustCameraSensitivity(-1);
        }

        m_pitch += Input.GetAxis("Mouse X") * m_sensitivity * Time.deltaTime;
        m_yaw += Input.GetAxis("Mouse Y") * m_sensitivity * Time.deltaTime;

        SetCameraClamp();

        transform.localRotation = Quaternion.Euler(-m_yaw, 0f, 0f);
        m_player.rotation = Quaternion.Euler(0f, m_pitch, 0f);
        
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

    private void AdjustCameraSensitivity(int adjustmentAmount)
    {
        m_sensitivity += adjustmentAmount;
        print(m_sensitivity);

        if (m_sensitivity < 10)
        {
            m_sensitivity = 10;
        }

        else if (m_sensitivity > 100)
        {
            m_sensitivity = 100;
        }
    }
}
