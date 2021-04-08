using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform playerTransform;

    private float _cameraOffset;

    [Range(0.01f, 1.0f)] public float smoothFactor;

    float newPosition;

    private void Start()
    {
        _cameraOffset = transform.position.z - playerTransform.position.z;

    }
    private void LateUpdate()
    {

        newPosition = playerTransform.position.z + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x, transform.position.y, newPosition), smoothFactor);

    }
}

