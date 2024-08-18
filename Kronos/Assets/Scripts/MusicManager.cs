using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource m_audioSource;

    [SerializeField] private SceneHandler m_sceneHandler;
    [SerializeField] private AudioClip m_ruminationsMusic;
    [SerializeField] private AudioClip m_festivalMusic;

    private const float MAX_VOLUME = 0.2f;

    public static float musicElapsed;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();

        if (SFXManager.s_isBackInTime)
        {
            m_audioSource.clip = null;
            if (m_sceneHandler.GetSceneName() == "Festival Area")
            {
                m_audioSource.clip = m_festivalMusic;
            }
        }

        PlayMusic();
    }

    private void Update()
    {
        musicElapsed = m_audioSource.time;
    }

    public void PlayMusic()
    {
        if (!m_audioSource.clip)
        {
            return;
        }

        m_audioSource.Play();
        StartCoroutine(FadeInMusic());
        m_audioSource.time = musicElapsed;
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
