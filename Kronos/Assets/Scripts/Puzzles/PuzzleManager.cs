using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement m_movementScript;
    [SerializeField] private PlayerCameraLook m_cameraScript;

    public void DisablePlayerControl()
    {
        m_movementScript.enabled = false;
        m_cameraScript.enabled = false;
    }

    public void EnablePlayerControl()
    {
        m_movementScript.enabled = true;
        m_cameraScript.enabled = true;
    }
}

//
// OLD CODE, MIGHT USE FOR LATER PURPOSES
//
/*public enum PuzzleStatus { Incomplete, Complete }

public class PuzzleManager : MonoBehaviour
{
    private Dictionary<string, PuzzleStatus> puzzles = new Dictionary<string, PuzzleStatus>();

    private void Start()
    {
        puzzles.Add("Tower of Paint", PuzzleStatus.Incomplete);
    }

    public PuzzleStatus GetPuzzleStatus(string puzzle)
    {
        if (!puzzles.ContainsKey(puzzle))
        {
            Debug.LogError("This puzzle name does not exist, double check you've spelled it correctly!");
            return PuzzleStatus.Incomplete;
        }

        return puzzles[puzzle];
    }

    public void PuzzleComplete(string puzzle)
    {
        if (!puzzles.ContainsKey(puzzle))
        {
            Debug.LogError("This puzzle name does not exist, double check you've spelled it correctly!");
            return;
        }

        puzzles[puzzle] = PuzzleStatus.Complete;
    }
}*/
