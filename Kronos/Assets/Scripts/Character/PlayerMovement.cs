using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rigidBody;

    [SerializeField] private int m_playerMoveSpeed;

    private Vector3 m_moveDir;

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
    }
}
