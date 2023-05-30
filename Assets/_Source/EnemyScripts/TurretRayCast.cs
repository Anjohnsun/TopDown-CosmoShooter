using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretRayCast : MonoBehaviour, IPausable
{

    public Transform ShootPoint;
    
    [SerializeField] private Transform _head;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private float _stopToAttackRadius;
    private Ray _ray = new Ray();
    private float dist;
    private bool _onPause = false;

    private float _actualReloadTime;


    private Transform _target;
    private bool _isPlayerInAgrRange = false;

    GameStates IPausable.CurrentGameState { get ; set ; }

    private void Start()
    {
        _actualReloadTime = _timeBetweenShoots;
        _agent.speed = _moveSpeed;
        _ray = new Ray(ShootPoint.position, transform.position);
        
        
    }
    private void Update()
    {
        if (_onPause == false)
        {


            _actualReloadTime -= Time.deltaTime;

            if (_isPlayerInAgrRange == true && _actualReloadTime <= 0)
            {

                _ray.direction = ShootPoint.forward;
                Debug.DrawRay(ShootPoint.position, ShootPoint.forward * 100, Color.green);

                _actualReloadTime += _timeBetweenShoots;

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && _onPause == false)
        {
            dist = Vector3.Distance(transform.position, other.transform.position);
            _target = other.gameObject.transform;
            
            if (dist <= _stopToAttackRadius)
            {
                _agent.enabled = false;
            }
            else
            {
                _agent.enabled = true;
            }
            _agent.SetDestination(_target.transform.position);
            Vector3 direction = _target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_head.rotation, look, _rotationSpeed * Time.deltaTime).eulerAngles;
            _head.rotation = Quaternion.Euler(0, rotation.y, 0);
            _isPlayerInAgrRange = true;
            

        }
    }
    private void OnTriggerExit(Collider other )
    {
        if (other.gameObject.layer == 7 && _onPause == false)
        {
            _isPlayerInAgrRange = false;
            _agent.enabled = false;
        }
    }

    public void OnGameStateChanged(GameStates newGameState)
    {
        _onPause = true;
    }

    void IPausable.OnGameStateChanged(GameStates newGameState)
    {
        
    }
}
