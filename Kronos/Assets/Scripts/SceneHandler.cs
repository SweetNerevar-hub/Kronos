using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scene Handler")]
public class SceneHandler : ScriptableObject
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
