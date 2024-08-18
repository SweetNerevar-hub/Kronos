using UnityEngine;

public class ExitCredits : MonoBehaviour
{
    [SerializeField] private SceneHandler m_sceneHandler;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_sceneHandler.ChangeSceneByName("Main Menu");
        }
    }
}
