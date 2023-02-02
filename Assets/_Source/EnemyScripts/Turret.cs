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
        [SerializeField] private float _hp;
        [SerializeField] private float _deathHpLvl;
        [SerializeField] private float _timeBetweenShoots;
        private float _actualReloadTime;
        
        
        private Transform _target;
        private bool _isPlayerInAgrRange = false;
        private void Start()
        {
            _actualReloadTime = _timeBetweenShoots;
        }
        private void Update()
        {
            _actualReloadTime -= Time.deltaTime;
            
            if (_isPlayerInAgrRange == true && _actualReloadTime <= 0)
            {
               
                Instantiate(_bulletPref, ShootPoint.position, ShootPoint.rotation);
               
                _actualReloadTime += _timeBetweenShoots;
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                
                _target = other.gameObject.transform;
               
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
            }
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
    }
}