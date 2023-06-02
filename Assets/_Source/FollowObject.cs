using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _followTarget.position, Time.deltaTime * 5);
    }
}
