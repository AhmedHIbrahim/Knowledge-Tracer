using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip audioClip;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle" && !audioSource.isPlaying)
        {

            audioSource.PlayOneShot(audioClip);
        }
    }


}
