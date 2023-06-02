using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;

public class CloseCombatEnemy : ADamagable, IPausable
{ 
    [SerializeField] private Transform _head;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stopToAttackRadius;
    [SerializeField] private float _timeBetweenStrikes;
    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    [SerializeField] private int _damage;
    [SerializeField] private AudioClip _detectionSound;
    [SerializeField] private AudioSource _audio;
    

    HealthModule healthModule;

    private float _actualReloadTime;
    private float _dist;
    private bool _onPause = false;
    private Transform _target;
    private bool _isPlayerInAgrRange = false;
    private bool _haveItSounded = false;

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
           
            
            if (_dist <= _stopToAttackRadius && _actualReloadTime <= 0)
            {
               
                if (healthModule != null)
                {
                    healthModule.GetDamage(_damage);
                }
               
                _actualReloadTime = _timeBetweenStrikes;
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

            _dist = Vector3.Distance(transform.position, other.transform.position);
            _target = other.gameObject.transform;
           
            if (_dist <= _stopToAttackRadius)
            {
                _agent.enabled = false;
                _target.TryGetComponent(out healthModule);
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

    override public void Damage()
    {
       
    }

    override public void Annihilate()
    {
        
    }
}
