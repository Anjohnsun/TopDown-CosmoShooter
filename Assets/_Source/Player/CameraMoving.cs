using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private Vector2 _cameraOffset;
    [SerializeField] private float _followingSpeed;

    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, _objectToFollow.position.x+_cameraOffset.x, _followingSpeed),
            transform.position.y,
            Mathf.Lerp(transform.position.z, _objectToFollow.position.z+ _cameraOffset.y, _followingSpeed));

    }
}
