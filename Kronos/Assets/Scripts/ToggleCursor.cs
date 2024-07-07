using UnityEngine;

public class ToggleCursor : MonoBehaviour
{
    [SerializeField] private SceneHandler m_sceneHandler;

    private PauseMenu m_menu;

    private void Start()
    {
        if (m_sceneHandler.GetSceneName() == "Main Menu")
        {
            ToggleCursorState(true);
            return;
        }

        ToggleCursorState(false);

        m_menu = GetComponentInParent<PauseMenu>();
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

    private void Update()
    {
        if (m_menu != null)
        {
            if (m_menu.isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void HideCursorAfterPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
