using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Transform _lookTarget;
    [SerializeField] private Animation _lightAnim;
    private bool canFollow = false;
    private Vector3 TargetPosition;
    private Quaternion OriginalRot;
    private Quaternion NewRot;

    void LateUpdate()
    {
        if (canFollow)
        {
            TargetPosition = new Vector3(_followTarget.position.x + 3.8f, transform.position.y, _followTarget.position.z - 7);
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * 3);

            transform.LookAt(_lookTarget);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            canFollow = true;
            _lightAnim.Play();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
