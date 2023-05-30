using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{


    public class Turret : MonoBehaviour
    {
        
        public Transform ShootPoint;
        
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private Transform _head;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _timeBetweenShoots;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
        [SerializeField] private float _stopToAttackRadius;
        private float _actualReloadTime;
        private float dist;
        
        
        
        private Transform _target;
        private bool _isPlayerInAgrRange = false;
        private void Start()
        {
            _actualReloadTime = _timeBetweenShoots;
            _agent.speed = _moveSpeed;
        }
        private void Update()
        {
            _actualReloadTime -= Time.deltaTime;
            
            if (_isPlayerInAgrRange == true && _actualReloadTime <= 0)
            {
               
                Instantiate(_bulletPref, ShootPoint.position, ShootPoint.rotation);
               
                _actualReloadTime = _timeBetweenShoots;
               
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                dist = Vector3.Distance(transform.position, other.transform.position);
                _target = other.gameObject.transform;
                if (dist <= _stopToAttackRadius)
                {
                    _agent.enabled = false;
                } else
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
            if (other.gameObject.layer == 7)
            {
                _isPlayerInAgrRange = false;
                _agent.enabled = false;
            }
        }
        
    }
}