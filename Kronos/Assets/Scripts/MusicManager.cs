using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource m_audioSource;

    [SerializeField] private AudioClip m_music;

    private const float MAX_VOLUME = 0.2f;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        PlayMusic(m_music);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        m_audioSource.clip = musicClip;
        m_audioSource.Play();
        StartCoroutine(FadeInMusic());
    }

    private IEnumerator FadeInMusic()
    {
        m_audioSource.volume = 0f;

        while (m_audioSource.volume < MAX_VOLUME)
        {
            m_audioSource.volume += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime * 5f);
        }

        yield return null;
    }
}
