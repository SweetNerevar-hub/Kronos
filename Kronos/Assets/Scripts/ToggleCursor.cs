using UnityEngine;

public class ToggleCursor : MonoBehaviour
{
    [SerializeField] private SceneHandler m_sceneHandler;

    private void Start()
    {
        if (m_sceneHandler.GetSceneIndex() == 0)
        {
            ToggleCursorState(true);
            return;
        }

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
