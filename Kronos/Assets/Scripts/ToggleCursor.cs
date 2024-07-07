using UnityEngine;

public class ToggleCursor : MonoBehaviour
{
    [SerializeField] private SceneHandler m_sceneHandler;

    private void Start()
    {
        //if (m_sceneHandler.GetSceneName() == "Main Menu")
        //{
        //    ToggleCursorState(true);
        //    return;
        //}

        //ToggleCursorState(false);
        Cursor.lockState = CursorLockMode.Locked; //temp will delete
        Cursor.visible = false; //temp will delete
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
