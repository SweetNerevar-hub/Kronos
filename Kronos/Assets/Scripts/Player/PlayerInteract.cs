using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float m_interactDistance;
    [SerializeField] private Transform m_holdPos;
    [SerializeField] private Image m_crosshair;

    private IPickupable m_heldObject;

    private void Update()
    {
        SendRaycast();

        if (Input.GetMouseButtonDown(1) && m_heldObject != null)
        {
            DropObject();
        }
    }

    private void FixedUpdate()
    {
        if (m_heldObject != null)
        {
            m_heldObject.SetHeldPosition(m_holdPos);
        }
    }

    private void SendRaycast()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * m_interactDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, m_interactDistance))
        {
            if (hit.collider.tag != "Interactable")
            {
                SetCrosshairColour(Color.white);
                return;
            }

            SetCrosshairColour(Color.green);

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.TryGetComponent(out IPickupable pickup))
                {
                    PickupObject(pickup);
                    return;
                }

                hit.collider.GetComponent<IInteractable>().Interact();
            }
        }

        else
        {
            SetCrosshairColour(Color.white);
        }
    }

    private void SetCrosshairColour(Color colour)
    {
        m_crosshair.color = colour;
    }

    private void PickupObject(IPickupable pickup)
    {
        if (pickup.IsValidPickUp())
        {
            pickup.Pickup();
            m_heldObject = pickup;
        }
    }

    private void DropObject()
    {
        m_heldObject.Drop();
        m_heldObject = null;
    }
}
