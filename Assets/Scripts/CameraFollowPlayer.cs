using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // This script should be attached to the camera
    public Transform playerTransform;  // It will listen the player position
    private float _cameraOffset;       // distance between camera and player
    [Range(0.01f, 1.0f)] public float smoothFactor;



    private void Start()
    {
        _cameraOffset = transform.position.z - playerTransform.position.z; // Initail distance between camera and the player

    }

    //LateUpdate is called once per frame, after Update has finished
    private void LateUpdate()
    {

        float newZPosition = playerTransform.position.z + _cameraOffset;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZPosition);
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);  // updates the camera position

    }
}

