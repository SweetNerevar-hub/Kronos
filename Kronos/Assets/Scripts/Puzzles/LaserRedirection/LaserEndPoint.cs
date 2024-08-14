using UnityEngine;

public class LaserEndPoint : MonoBehaviour
{
    private Material m_highlight;
    [SerializeField] private bool m_isComplete;

    private void Start()
    {
        m_highlight = GetComponent<MeshRenderer>().materials[1];
    }

    public void CompletePuzzle()
    {
        if (!m_isComplete)
        {
            print("YOU COMPLETED THIS PUZZLE");
            m_highlight.EnableKeyword("_EMISSION");
            m_isComplete = true;
        }
    }
}
