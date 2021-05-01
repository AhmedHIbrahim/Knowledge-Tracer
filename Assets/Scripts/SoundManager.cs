using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip envClip;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();


    }

    public void PlayEnvironmentSound()
    {
        audioSource.loop = true;
        audioSource.volume = 1;
        audioSource.clip = envClip;
        audioSource.Play();
    }

    public void PauseSound()
    {
        if (audioSource != null)
            audioSource.Pause();

    }

    public void ResumeSound()
    {
        if (audioSource != null)
            audioSource.Play();
    }

}
