using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace PlayerSystems
{
    public class PlayerNavigation : MonoBehaviour, IPausable
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _dodgeDistance;
        [SerializeField] private float _dodgeDuration;
        [SerializeField] private Transform _movingCorrector;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private LayerMask _obstacleMask;

        private PlayerInput _playerInput;
        private bool _canMove;

        [HideInInspector] public UnityEvent<bool> OnLockActions = new UnityEvent<bool>();

        GameStates IPausable.CurrentGameState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerInput.Player.Dive.started += context => MakeDodge();
            _canMove = true;

            OnLockActions.AddListener(LockMovement);
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

        private void OnCollisionEnter(Collision collision)
        {
            if (_obstacleMask == (_obstacleMask | (1 << collision.gameObject.layer)))
            {
                DOTween.Kill(transform);
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
            _rigidBody.AddForce((_movingCorrector.forward * way.y + _movingCorrector.right * way.x) * _moveSpeed, ForceMode.Acceleration);
            if (_rigidBody.velocity.magnitude > _moveSpeed)
                _rigidBody.velocity = _rigidBody.velocity.normalized * _moveSpeed;
        }

        private void MakeDodge()
        {
            if (_canMove)
            {
                transform.DOMove(transform.position + transform.forward * _dodgeDistance, _dodgeDuration).SetEase(Ease.InOutQuad);

                LockActions(true);
                Invoke("UnlockActions", _dodgeDuration);
            }
        }

        private void LockMovement(bool def)
        {
            switch (def)
            {
                case true:
                    _canMove = false;
                    break;
                case false:
                    _rigidBody.velocity = new Vector3();
                    _canMove = true;
                    break;
            }
        }

        private void LockActions(bool def)
        {
            OnLockActions.Invoke(def);
        }

        private void UnlockActions()
        {
            OnLockActions.Invoke(false);
        }

        public void OnGameStateChanged(GameStates newGameState)
        {
            switch (newGameState)
            {
                case GameStates.Paused:
                    _canMove = false;
                    break;
                case GameStates.Playing:
                    _canMove = true;
                    break;
            }
        }
    }
}