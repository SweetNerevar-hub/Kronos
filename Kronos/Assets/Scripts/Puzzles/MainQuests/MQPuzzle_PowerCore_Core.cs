using UnityEngine;
using TMPro;
using System.Collections;
using PixelCrushers.DialogueSystem;
using PixelCrushers;

public class MQPuzzle_PowerCore_Core : MonoBehaviour
{
    private MeshRenderer m_meshRenderer;

    [SerializeField] private MQPuzzle_PowerCore_ControlPanel m_controlPanel;

    /*[SerializeField] private Material m_coreUnlit;
    [SerializeField] private Material m_coreLit;*/

    [SerializeField] private AudioClip m_keyPressedAudio;
    [SerializeField] private AudioClip m_succeedAudio;
    [SerializeField] private AudioClip m_failedAudio;

    [Header("Code Related Fields")]
    [SerializeField] private int[] m_code;
    [SerializeField] private TMP_Text m_codeText;
    private string m_codeString;
    private string m_inputCode;

    private int m_pulseCount;
    private int m_codeSequenceCount;
    private float m_pulseTime;
    private bool m_coreLightOn;

    private bool m_isCompleted;

    private const float TIME_BETWEEN_PULSES_SHORT = 0.3f;
    private const float TIME_BETWEEN_PULSES_LONG = 2f;

    public bool IsCompleted
    {
        get { return m_isCompleted; }
    }

    [SerializeField] private ScenePortal scenePortal;
    private void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();

        m_pulseTime = TIME_BETWEEN_PULSES_LONG;

        SetCodeToString();
    }

    private void Update()
    {
        if (!m_isCompleted)
        {
            HandlePulseTime();
        }
    }

    public void KeypadInput(int key)
    {
        if (m_isCompleted)
        {
            return;
        }

        m_inputCode += key.ToString();
        m_codeText.text = m_inputCode;

        SFXManager.Instance.PlayAudio(m_keyPressedAudio);

        if (m_inputCode == m_codeString)
        {
            m_isCompleted = true;
            print("YOU COMPLETED THE PUZZLE!");
            m_inputCode = "";

            m_controlPanel.DoOpenControlPanel(false);

            // Dialogue/Bark about how stabilising the power core doesn't seem to have given the ship power

            SFXManager.Instance.PlayAudio(m_succeedAudio);

            SetPowerCoreMaterial(true);
            StartCoroutine(GoToCredits());
        }

        else if (m_inputCode.Length == m_code.Length)
        {
            m_inputCode = "";
            m_codeText.text = m_inputCode;
            print("Wrong Code!");

            SFXManager.Instance.PlayAudio(m_failedAudio);
        }
    }

    private IEnumerator GoToCredits()
    {
        yield return new WaitForSeconds(3);
        DialogueLua.SetVariable("GoToCredits", true);
        scenePortal.UsePortal();
    }

    private void SetCodeToString()
    {
        for (int i = 0; i < m_code.Length; i++)
        {
            m_codeString += m_code[i].ToString();
        }
    }

    private void HandlePulseTime()
    {
        m_pulseTime -= Time.deltaTime;

        if (m_pulseTime <= 0f)
        {
            TogglePowerCoreLight();
        }
    }

    private void TogglePowerCoreLight()
    {
        m_coreLightOn = !m_coreLightOn;
        SetPulseTime(TIME_BETWEEN_PULSES_SHORT);

        if (m_coreLightOn)
        {
            HandlePulseCount();
        }

        else
        {
            SetPowerCoreMaterial(false);
        }
    }

    private void HandlePulseCount()
    {
        m_pulseCount++;
        SetPowerCoreMaterial(true);

        if (m_pulseCount == m_code[m_codeSequenceCount] + 1)
        {
            m_codeSequenceCount++;
            m_pulseCount = 0;

            TogglePowerCoreLight();
            SetPulseTime(TIME_BETWEEN_PULSES_LONG);
        }

        CheckForCodeSequenceReset();
    }

    private void CheckForCodeSequenceReset()
    {
        if (m_codeSequenceCount == m_code.Length)
        {
            m_codeSequenceCount = 0;
        }
    }

    private void SetPulseTime(float newTime)
    {
        m_pulseTime = newTime;
    }

    private void SetPowerCoreMaterial(bool t)
    {
        if (!t)
        {
            m_meshRenderer.materials[3].DisableKeyword("_EMISSION");
            return;
        }

        m_meshRenderer.materials[3].EnableKeyword("_EMISSION");
    }
}
