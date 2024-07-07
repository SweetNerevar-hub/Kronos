using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    private AudioSource m_audioSource;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(Instance);
        }

        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        m_audioSource.pitch = 1f;
        m_audioSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Plays an audio clip with a random pitch inbetween the twwo given values
    /// </summary>
    /// <param name="clip"> The audio clip that will play </param>
    /// <param name="minPitch"> The minimum pitch </param>
    /// <param name="maxPitch"> The maximum pitch </param>
    public void PlayAudioRandomPitch(AudioClip clip, float minPitch, float maxPitch)
    {
        float pitch = Random.Range(minPitch, maxPitch);

        m_audioSource.pitch = pitch;
        m_audioSource.PlayOneShot(clip);
    }
}