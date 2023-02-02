using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _health;

        private WeaponStateMachine _weaponMachine;

        private void Start()
        {
            //подписка на инпут
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                StartAttack();
        }

        public void StartAttack()
        {
            if(_weaponMachine._currentWeapon != null)
            _weaponMachine._currentWeapon.StartAttack();
        }
        public void StopAttack()
        {
            if (_weaponMachine._currentWeapon != null)
                _weaponMachine._currentWeapon.StartAttack();
        }
        public void Reload()
        {
            if (_weaponMachine._currentWeapon != null)
                _weaponMachine._currentWeapon.StartAttack();
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //animate death
            //restart level
        }
    }
}