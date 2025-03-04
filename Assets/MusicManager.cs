using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate MusicManager on restart
        }
    }

    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Pause();  // Use Pause instead of Stop to allow resuming
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void RestartMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();  // Fully stops the track
            audioSource.Play();  // Restarts from the beginning
        }
    }
}
