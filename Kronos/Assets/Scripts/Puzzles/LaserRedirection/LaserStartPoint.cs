using UnityEngine;

public class LaserStartPoint : MonoBehaviour
{
    private LaserRedirector m_lastRedirectorHit;
    private LineRenderer m_lineRenderer;

    private const int c_rayDistance = 100;

    private void Start()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, c_rayDistance))
        {
            m_lineRenderer.SetPosition(1, new Vector3(0f, 0f, hit.distance));

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
        }

        else
        {
            m_lineRenderer.SetPosition(1, new Vector3(0f, 0f, 20f));

            if (m_lastRedirectorHit)
            {
                m_lastRedirectorHit.WillActivateRedirector(false);
            }
        }
    }
}
