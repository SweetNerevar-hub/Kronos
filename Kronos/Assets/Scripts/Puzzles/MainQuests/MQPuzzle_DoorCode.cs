using UnityEngine;
using TMPro;

public class MQPuzzle_DoorCode : MonoBehaviour, IInteractable
{
    [SerializeField] private PuzzleManager m_puzzleManager;

    [SerializeField] private int[] m_safeCode;
    [SerializeField] private bool[] m_hasCorrectCodeOrder;
    [SerializeField] private TMP_Text m_codeOutputText;
    [SerializeField] private TMP_Text m_currentAngleText;

    [SerializeField] private AudioClip m_turnDialAudio;
    [SerializeField] private AudioClip m_puzzleCompleteAudio;
    [SerializeField] private AudioClip m_puzzleFailAudio;

    private bool m_isActivated;
    private bool m_isCompleted;

    private const int DIAL_ROTATE_AMOUNT = 15;
    private int m_currentAngle;

    public void Interact()
    {
        if (!m_isCompleted)
        {
            ActivatePuzzle();
            return;
        }

        print("You've already completed this puzzle!");
    }

    private void Update()
    {
        if (m_isActivated)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                RotateDialLeft();
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                RotateDialRight();
            }

            else if (Input.GetMouseButtonDown(1))
            {
                DeactivatePuzzle();
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckForCorrectAngle();
            }
        }
    }

    private void RotateDialLeft()
    {
        SFXManager.Instance.PlayAudio(m_turnDialAudio);

        m_currentAngle -= DIAL_ROTATE_AMOUNT;
        CheckForIntWrapping();
        transform.rotation = Quaternion.Euler(m_currentAngle, transform.rotation.y, transform.rotation.z);

        m_currentAngleText.text = m_currentAngle.ToString();
    }

    private void RotateDialRight()
    {
        SFXManager.Instance.PlayAudio(m_turnDialAudio);

        m_currentAngle += DIAL_ROTATE_AMOUNT;
        CheckForIntWrapping();
        transform.rotation = Quaternion.Euler(m_currentAngle, transform.rotation.y, transform.rotation.z);

        m_currentAngleText.text = m_currentAngle.ToString();
    }

    private void CheckForCorrectAngle()
    {
        for (int i = 0; i < m_safeCode.Length; i++)
        {
            if (!m_hasCorrectCodeOrder[i])
            {
                if (m_currentAngle == m_safeCode[i])
                {
                    m_hasCorrectCodeOrder[i] = true;
                    m_codeOutputText.text += $"{m_safeCode[i]}-";
                    print("That was the correct number");
                    CheckForPuzzleCompletion();
                    break;
                }

                print("That was the incorrect number");
                ResetCode();
                break;
            }
        }
    }

    private void ResetCode()
    {
        for (int i = 0; i < m_hasCorrectCodeOrder.Length; i++)
        {
            m_hasCorrectCodeOrder[i] = false;

            m_codeOutputText.text = "";
            SFXManager.Instance.PlayAudio(m_puzzleFailAudio);
        }
    }

    private void CheckForPuzzleCompletion()
    {
        if (m_hasCorrectCodeOrder[2])
        {
            print("You cracked the safe!");
            m_isCompleted = true;
            DeactivatePuzzle();
            SFXManager.Instance.PlayAudio(m_puzzleCompleteAudio);
        }
    }

    private void CheckForIntWrapping()
    {
        if (m_currentAngle < 0)
        {
            m_currentAngle = 360 - DIAL_ROTATE_AMOUNT;
        }

        if (m_currentAngle >= 360f)
        {
            m_currentAngle = 0;
        }
    }

    public void ActivatePuzzle()
    {
        m_isActivated = true;
        m_puzzleManager.DisablePlayerControl();

        m_currentAngleText.text = $"{m_currentAngle}";
    }

    public void DeactivatePuzzle()
    {
        m_isActivated = false;
        m_puzzleManager.EnablePlayerControl();

        m_codeOutputText.text = "";
        m_currentAngleText.text = "";
    }
}
