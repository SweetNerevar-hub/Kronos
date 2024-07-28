using UnityEngine;

public class LaserEndPoint : MonoBehaviour
{
    [SerializeField] private bool m_isComplete;

    public void CompletePuzzle()
    {
        if (!m_isComplete)
        {
            print("YOU COMPLETED THIS PUZZLE");
            m_isComplete = true;
        }
    }
}
