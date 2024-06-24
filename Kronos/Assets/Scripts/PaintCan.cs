using UnityEngine;

public enum CanSize { Small, Medium, Large }

public class PaintCan : MonoBehaviour, IPickupable
{
    private Rigidbody m_rb;

    [SerializeField] private Transform m_rayOrigin;
    [SerializeField] private float m_lerpSpeed;

    [field: SerializeField] public CanSize CanSize { get; private set; }

    [SerializeField] private bool m_canBePickedUp;
    private bool m_isInBounds;
    private bool m_isBeingHeld;
    private Vector3 m_resetPosition;
    private Vector3 m_currentBoundsPosition;

    private const float MAX_DRAG = 10f;
    private const float MIN_DRAG = 0f;
    private const float RAY_LENGTH = 0.1f;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_rb.velocity != Vector3.zero)
        {
            SendRaycast();
            return;
        }

        else if (m_rb.velocity == Vector3.zero && m_isInBounds && !m_isBeingHeld)
        {
            m_resetPosition = m_currentBoundsPosition;
        }
    }

    private void SendRaycast()
    {
        RaycastHit hit;

        Debug.DrawRay(m_rayOrigin.position, Vector3.down * RAY_LENGTH, Color.red);

        if (Physics.Raycast(m_rayOrigin.position, Vector3.down, out hit, RAY_LENGTH))
        {
            if (!m_isInBounds && !m_isBeingHeld && hit.collider.name == "Floor")
            {
                ResetToLastPosition();
                return;
            }

            if (hit.collider.TryGetComponent(out PaintCan can))
            {
                if ((int)CanSize > (int)can.CanSize)
                {
                    ResetToLastPosition();
                }
            }
        }
    }

    private void ResetToLastPosition()
    {
        m_rb.velocity = Vector3.zero;
        m_rb.position = m_resetPosition;
    }

    public void Pickup()
    {
        m_isBeingHeld = true;
        m_rb.useGravity = false;
        m_rb.drag = MAX_DRAG;
    }

    public void Drop()
    {
        m_isBeingHeld = false;
        m_rb.useGravity = true;
        m_rb.drag = MIN_DRAG;
    }

    public void SetHeldPosition(Transform holdPos)
    {
        m_rb.velocity += (holdPos.position - transform.position) * m_lerpSpeed * Time.deltaTime;
    }

    public void SetBoundsPosition(Vector3 pos)
    {
        m_currentBoundsPosition = pos;
    }

    public bool IsValidPickUp()
    {
        return m_canBePickedUp;
    }

    public void SetInBoundsFlag(bool flag)
    {
        m_isInBounds = flag;
    }

    public void SetPickupFlag(bool flag)
    {
        m_canBePickedUp = flag;
    }

    public bool IsHeld()
    {
        return m_isBeingHeld;
    }
}
