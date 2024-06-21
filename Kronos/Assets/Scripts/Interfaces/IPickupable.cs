using UnityEngine;

public interface IPickupable
{
    void Pickup();
    void Drop();
    void SetHeldPosition(Transform holdPos);
    bool IsValidPickUp();
}
