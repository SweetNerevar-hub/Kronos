using UnityEngine;

public class LaserRedirector : MonoBehaviour, IPickupable
{
    private Rigidbody m_rb;
    private LineRenderer m_lineRenderer;
    private LaserRedirector m_lastRedirectorHit;
    private Material m_glassMaterial;

    [SerializeField] private Transform m_rayPoint;

    private int m_lerpSpeed = 150;
    [SerializeField] private bool m_isHit;

    private const int c_rayDistance = 100;
    private const int c_maxDrag = 10;
    private const int c_minDrag = 0;

    public bool IsHit
    {
        get { return m_isHit; }
        set { m_isHit = value; }
    }

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_lineRenderer = m_rayPoint.GetComponent<LineRenderer>();
        m_glassMaterial = GetComponent<MeshRenderer>().materials[1];

        print(m_glassMaterial.name);
    }

    private void Update()
    {
        if (!m_isHit)
        {
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(m_rayPoint.position, m_rayPoint.forward, out hit, c_rayDistance))
        {
            m_lineRenderer.SetPosition(1, new Vector3(0f, 0f, hit.distance / transform.localScale.z));

            if (hit.collider.TryGetComponent(out LaserRedirector redirector))
            {
                if (!redirector.IsHit)
                {
                    redirector.WillActivateRedirector(true);
                }

                m_lastRedirectorHit = redirector;
            }

            else
            {
                if (m_lastRedirectorHit)
                {
                    m_lastRedirectorHit.WillActivateRedirector(false);
                }
            }

            if (hit.collider.TryGetComponent(out LaserEndPoint endPoint))
            {
                endPoint.CompletePuzzle();
            }
        }

        else
        {
            m_lineRenderer.SetPosition(1, new Vector3(0f, 0f, c_rayDistance));

            if (m_lastRedirectorHit)
            {
                m_lastRedirectorHit.WillActivateRedirector(false);
            }
        }
    }

    public void WillActivateRedirector(bool toggle)
    {
        m_isHit = toggle;
        m_lineRenderer.enabled = toggle;

        if (toggle)
        {
            m_glassMaterial.EnableKeyword("_EMISSION");
            //m_glassMaterial.color = Color.red;
        }

        else
        {
            m_glassMaterial.DisableKeyword("_EMISSION");
            //m_glassMaterial.color = Color.white;
        }
    }

    public void Pickup()
    {
        m_rb.useGravity = false;
        m_rb.drag = c_maxDrag;
    }

    public void Drop()
    {
        m_rb.useGravity = true;
        m_rb.drag = c_minDrag;
    }

    public void SetHeldPosition(Transform holdPos)
    {
        transform.rotation = holdPos.rotation;
        m_rb.velocity += (holdPos.position - transform.position) * m_lerpSpeed * Time.deltaTime;
    }

    public bool IsValidPickUp()
    {
        return true;
    }
}
