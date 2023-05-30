using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombatEnemy : MonoBehaviour, IPausable
{ 
    [SerializeField] private Transform _head;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _inRangeCheckPoint;
    [SerializeField] private float _timeBetweenStrikes;
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    private float _actualReloadTime;
    private Ray _ray = new Ray();
    private bool _onPause = false;

    private Transform _target;
    private bool _isPlayerInAgrRange = false;

    GameStates IPausable.CurrentGameState { get; set; }

    private void Start()
    {
        _actualReloadTime = _timeBetweenStrikes;
        _agent.speed = _moveSpeed;

        GameStateMachine.StateChanged += OnGameStateChanged;
    }
    private void Update()
    {
        if (_onPause == false)
        {
            _actualReloadTime -= Time.deltaTime;
            _ray = new Ray(_inRangeCheckPoint.position, transform.forward);
            Debug.DrawRay(_inRangeCheckPoint.position, transform.forward, Color.green);
            if (Physics.Raycast(_ray) && _actualReloadTime <= 0)
            {
                _actualReloadTime += _timeBetweenStrikes;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && _onPause == false)
        {
            _target = other.gameObject.transform;
            _agent.enabled = true;
            _agent.SetDestination(_target.transform.position);
            Vector3 direction = _target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_head.rotation, look, _rotationSpeed * Time.deltaTime).eulerAngles;
            _head.rotation = Quaternion.Euler(0, rotation.y, 0);
            _isPlayerInAgrRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 && _onPause == false)
        {
            _isPlayerInAgrRange = false;
            _agent.enabled = false;
        }
    }

    public void OnGameStateChanged(GameStates newGameState)
    {
        throw new System.NotImplementedException();
    }

    private void OnDestroy()
    {
        GameStateMachine.StateChanged -= OnGameStateChanged;
    }
}
