using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlayerSystems
{
    public class PlayerNavigation : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _sprintPower;
        [SerializeField] private float _diveDuration;
        [SerializeField] private Transform _movingCorrector;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Rigidbody _rigidBody;

        private PlayerInput _playerInput;
        private bool _canMove;

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerInput.Player.Dive.started += context => Dive();
            _canMove = true;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        void Update()
        {
            if (_canMove)
            {
                Physics.Raycast(_playerCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
                RotateToPoint(hit);

                Move(_playerInput.Player.Move.ReadValue<Vector2>());
            }
        }

        private void RotateToPoint(RaycastHit hit)
        {
            Vector3 diff = hit.point - transform.position;
            diff.Normalize();

            float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * _rotateSpeed);
        }

        private void Move(Vector2 way)
        {
            _rigidBody.AddForce(new Vector3(way.x, 0, way.y) * _moveSpeed, ForceMode.Acceleration);
            if (_rigidBody.velocity.magnitude > _moveSpeed)
                _rigidBody.velocity = _rigidBody.velocity.normalized * _moveSpeed;
        }

        private void Dive()
        {
            _rigidBody.velocity = new Vector3();
            _rigidBody.AddForce(transform.forward * _sprintPower, ForceMode.Impulse);

            LockActions();
            Invoke( "UnlockActions", _diveDuration);
        }

        private void LockActions()
        {
            Debug.Log("lock");
                _canMove = false;
                _playerInput.Player.Dive.performed -= context => Dive();

        }

        private void UnlockActions()
        {
            Debug.Log("open");
            _canMove = true;
            _playerInput.Player.Dive.performed += context => Dive();
        }
    }
}