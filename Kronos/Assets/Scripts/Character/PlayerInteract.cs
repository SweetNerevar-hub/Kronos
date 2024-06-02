using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float m_interactDistance;

    private void Update()
    {
        SendRaycast();
    }

    private void SendRaycast()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * m_interactDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, m_interactDistance))
        {
            // Change cursor color when the raycast hits something that can be interacted with
            // Otherwise change it back to default color

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == "Interactable")
                {
                    hit.collider.GetComponent<IInteractable>().Interact();
                }
            }
        }
    }
}
