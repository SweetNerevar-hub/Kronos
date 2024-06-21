using UnityEngine;

public class ToggleCursor : MonoBehaviour
{
    private void Start()
    {
        ToggleCursorState(false);
    }

    public void ToggleCursorState(bool show)
    {
        if (show)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
