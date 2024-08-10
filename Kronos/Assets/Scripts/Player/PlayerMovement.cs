using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rigidBody;

    [SerializeField] private PlayerCameraBob m_headbobController;
    [SerializeField] private int m_playerMoveSpeed;
    [SerializeField] private AudioClip[] m_stepAudio;

    private Vector3 m_moveDir;

    private const float c_sprintMoveMultiplier = 1.5f;
    private const float c_strafeMoveMultiplier = 0.75f;
    private const float c_backwardsMoveMultiplier = 0.5f;
    private const float c_maxStepTime = 0.5f;

    private float m_stepTime;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        UpdatePlayerMovement();
        m_headbobController.ResetHeadbob();
    }

    private void UpdatePlayerMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        m_moveDir = transform.forward * v + transform.right * h;
        m_rigidBody.MovePosition(transform.position + m_moveDir * (m_playerMoveSpeed * GetMoveSpeedMultiplier(h, v)) * Time.fixedDeltaTime);

        {
            if (m_stepTime > 0f)
            {
                m_stepTime -= Time.fixedDeltaTime * GetMoveSpeedMultiplier(h, v);
            }

            if ((h != 0 || v != 0))
            {
                m_headbobController.Headbob(GetMoveSpeedMultiplier(h, v));

                if (m_stepTime <= 0f)
                {
                    PlayStepAudio();
                    m_stepTime = c_maxStepTime;
                }
            }
        }
    }

    private float GetMoveSpeedMultiplier(float h, float v)
    {
        if (Input.GetKey(KeyCode.LeftShift) && v > 0f)
        {
            return c_sprintMoveMultiplier;
        }

        if (h != 0f)
        {
            return c_strafeMoveMultiplier;
        }

        if (v < 0f)
        {
            return c_backwardsMoveMultiplier;
        }

        return 1f;
    }

    private void PlayStepAudio()
    {
        int r = Random.Range(0, m_stepAudio.Length);

        SFXManager.Instance.PlayAudio(m_stepAudio[r]);
    }
}
