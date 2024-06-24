using System.Collections.Generic;
using UnityEngine;

public enum PuzzleStatus { Incomplete, Complete }

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
}
