using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy 
{


    public class Enemy : MonoBehaviour,  IPausable
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _bulletPref;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _hp;
        // �
        
        [SerializeField] private Transform _head;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _timeBetweenShoots;
        private Transform _target;
        private float _actualReloadTime;
       
        private bool _ifPlayerInShoot = false;

        private void Start()
        {
            _actualReloadTime = _timeBetweenShoots;
            _agent.speed = _moveSpeed;
        }
        private void Update()
        {
            
            _actualReloadTime -= Time.deltaTime;
            
            
            
            if (_ifPlayerInShoot == true && _actualReloadTime <= 0)
            {
                Shoot();
                _actualReloadTime = _timeBetweenShoots;
            }
         
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                
                _target = other.gameObject.transform;
                _ifPlayerInShoot = true;
                _agent.enabled = true;
                //_agent.speed = _moveSpeed;
                _agent.SetDestination(_target.position);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                _ifPlayerInShoot = false;
                _agent.enabled = false;
                //_agent.speed = 0;
            }
        }
        private void Shoot()
        {
            

            Vector3 direction = _target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_head.rotation, look, _rotationSpeed * Time.deltaTime).eulerAngles;
            _head.rotation = Quaternion.Euler(0, rotation.y, 0);
            Instantiate(_bulletPref, _shootPoint.position, _shootPoint.rotation);
        }
        private void GetDamage(float dmg)
        {
            _hp -= dmg;
            if (_hp < 0)
            {
                Death();
            }
        }
        private void Death()
        {

        }

        public void OnGameStateChanged(GameStates newGameState)
        {
            
        }
    }
}
