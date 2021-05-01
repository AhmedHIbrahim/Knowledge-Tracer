using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip collisionClip;
    public GameObject CanvasManager;

    int numOfCollisions;
    public Image mask;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        numOfCollisions = 0;
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle" && !audioSource.isPlaying)
        {

            audioSource.PlayOneShot(collisionClip);
            numOfCollisions++;
            mask.fillAmount = (5f - numOfCollisions) / 5f;
            if (mask.fillAmount == 0)
            {
                CanvasManager.GetComponent<CanvasManager>().GameOver();

            }
        }
    }
}
