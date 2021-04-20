using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip envClip;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void PlayEnvironmentSound()
    {
        audioSource.PlayOneShot(envClip);
    }
}
