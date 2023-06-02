using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Transform _lookTarget;
    [SerializeField] private Animation _lightAnim;
    private Vector3 TargetPosition;

    void LateUpdate()
    {
        TargetPosition = new Vector3(_followTarget.position.x + 3.8f, transform.position.y, _followTarget.position.z - 7);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * 3);

        transform.LookAt(_lookTarget);
    }
}
