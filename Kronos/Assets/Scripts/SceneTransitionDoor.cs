using UnityEngine;

public class SceneTransitionDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private SceneHandler m_sceneHandler;
    [SerializeField] private string m_sceneName;

    public void Interact()
    {
        m_sceneHandler.ChangeSceneByName(m_sceneName);
    }
}
