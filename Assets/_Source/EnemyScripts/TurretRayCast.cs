using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;


public class TurretRayCast : MonoBehaviour, IPausable, IDamagable
{

    public Transform ShootPoint;
    
    [SerializeField] private Transform _head;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private float _stopToAttackRadius;
    [SerializeField] private int _damage;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _detectionSound;

    HealthModule healthModule;

    private Ray _ray = new Ray();
    private float dist;
    private bool _onPause = false;
    private float _actualReloadTime;
    private Transform _target;
    private bool _isPlayerInAgrRange = false;
    private bool _haveItSounded = false;

    GameStates IPausable.CurrentGameState { get ; set ; }

    private void Start()
    {
        _actualReloadTime = _timeBetweenShoots;
        _agent.speed = _moveSpeed;
        _ray = new Ray(ShootPoint.position, transform.position);


        GameStateMachine.StateChanged += OnGameStateChanged;
    }
    private void Update()
    {
        if (_onPause == false)
        {
            _actualReloadTime -= Time.deltaTime;

            if (_isPlayerInAgrRange == true && _actualReloadTime <= 0)
            {

                _ray.direction = ShootPoint.forward;
                _audio.clip = _shootSound;
                _audio.Play();
                RaycastHit _hit;
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.transform.gameObject.layer == 7)
                    {
                        _hit.transform.TryGetComponent(out healthModule);
                        //healthModule.GetDamage(_damage);
                    }
                   
                }

                _actualReloadTime = _timeBetweenShoots;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && _onPause == false)
        {
            if (_haveItSounded == false)
            {
                _audio.clip = _detectionSound;
                _audio.Play();
                _haveItSounded = true;
            }

            dist = Vector3.Distance(transform.position, other.transform.position);
            _target = other.gameObject.transform;
            
            if (dist <= _stopToAttackRadius)
            {
                _agent.enabled = false;
            }
            else
            {
                _agent.enabled = true;
                _agent.SetDestination(_target.transform.position);
            }
           
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
            _haveItSounded = false;
        }
    }

    public void OnGameStateChanged(GameStates newGameState)
    {
        _onPause = true;
    }

    private void OnDestroy()
    {
        GameStateMachine.StateChanged -= OnGameStateChanged;
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }

    public void Annihilate()
    {
        throw new System.NotImplementedException();
    }
}
