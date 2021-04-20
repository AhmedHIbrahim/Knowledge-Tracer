using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip collisionClip;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle" && !audioSource.isPlaying)
        {

            audioSource.PlayOneShot(collisionClip);
        }
    }


}
