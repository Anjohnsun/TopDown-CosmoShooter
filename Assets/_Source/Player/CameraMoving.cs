using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private float _followingSpeed;


    private void Start()
    {
        transform.position = new Vector3(
            transform.position.x,
            _objectToFollow.position.y + _cameraOffset.y,
            transform.position.z);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, _objectToFollow.position.x+_cameraOffset.x, _followingSpeed),
            Mathf.Lerp(transform.position.y, _objectToFollow.position.y + _cameraOffset.y, _followingSpeed),
            Mathf.Lerp(transform.position.z, _objectToFollow.position.z+ _cameraOffset.z, _followingSpeed));
    }
}
