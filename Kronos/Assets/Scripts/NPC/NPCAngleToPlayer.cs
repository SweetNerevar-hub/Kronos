using UnityEngine;

public class NPCAngleToPlayer : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;

    [SerializeField] private Sprite m_facingForward;
    [SerializeField] private Sprite m_facingRight;
    [SerializeField] private Sprite m_facingLeft;
    [SerializeField] private Sprite m_facingBackward;

    private Transform m_player;

    private void Start()
    {
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.GetChild(0).LookAt(m_player);

        float angle = Vector3.SignedAngle(m_player.position - transform.position, transform.forward, Vector3.up);

        if (angle >= -45f && angle <= 45f)
        {
            m_spriteRenderer.sprite = m_facingForward;
        }

        else if (angle <= 135f && angle >= 45f)
        {
            m_spriteRenderer.sprite = m_facingRight;
        }

        else if (angle <= -45f & angle >= -135f)
        {
            m_spriteRenderer.sprite = m_facingLeft;
        }

        else if (angle >= 135f && angle <= 180f || angle <= -135f && angle >= -180f)
        {
            m_spriteRenderer.sprite = m_facingBackward;
        }
    }
}
