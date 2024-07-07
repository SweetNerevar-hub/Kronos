using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rigidBody;

    [SerializeField] private int m_playerMoveSpeed;
    [SerializeField] private AudioClip[] m_stepAudio;

    private Vector3 m_moveDir;

    private const float MAX_STEP_TIME = 0.5f;
    private float m_stepTime;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        m_moveDir = transform.forward * v + transform.right * h;
        m_rigidBody.velocity = m_moveDir * m_playerMoveSpeed;

        // Checks for whether to play a step sound or not
        {
            if (m_stepTime > 0f)
            {
                m_stepTime -= Time.deltaTime;
            }

            if (m_rigidBody.velocity != Vector3.zero && m_stepTime <= 0f)
            {
                PlayStepAudio();
                m_stepTime = MAX_STEP_TIME;
            }
        }
    }

    private void PlayStepAudio()
    {
        int r = Random.Range(0, m_stepAudio.Length);

        SFXManager.Instance.PlayAudio(m_stepAudio[r]);
    }
}
