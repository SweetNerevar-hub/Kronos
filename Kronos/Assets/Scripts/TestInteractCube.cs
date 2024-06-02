using UnityEngine;

public class TestInteractCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        print("You hit: " + name);
    }
}
