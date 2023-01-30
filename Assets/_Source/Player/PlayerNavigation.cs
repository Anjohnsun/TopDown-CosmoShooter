using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
    {
    public class PlayerNavigation : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Transform _movingCorrector;
        [SerializeField] private Camera _playerCamera;

        void Start()
        {
            //subscribe on Input
        }

        void Update()
        {
            Physics.Raycast(_playerCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            RotateToPoint(hit);

            MoveHorizontally(Input.GetAxis("Horizontal"));
            MoveVertically(Input.GetAxis("Vertical"));
        }

        private void RotateToPoint(RaycastHit hit)
        {
            Vector3 diff = hit.point - transform.position;
            diff.Normalize();

            float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * _rotateSpeed);
        }

        public void MoveVertically(float axisValue)
        {
            transform.position += _movingCorrector.forward * axisValue * _moveSpeed;
        }

        public void MoveHorizontally(float axisValue)
        {
            transform.position += _movingCorrector.right * axisValue * _moveSpeed;
        }

    }
}