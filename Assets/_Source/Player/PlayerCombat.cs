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
        [SerializeField] private List<AWeapon> _weapons;

        [SerializeField] private InputSystem _inputSystem;

        private void Start()
        {
            _weaponMachine = new WeaponStateMachine();
            _weaponMachine.InitStates(_weapons);

            _inputSystem.Interacted += Reload;
            _inputSystem.StartedAttack += StartAttack;
            _inputSystem.StopedAttack += StopAttack;
        }

        private void Update() //временно
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                ChangeWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                ChangeWeapon(2);
        }

        public void StartAttack()
        {
            if (_weaponMachine._currentWeapon != null)
                _weaponMachine._currentWeapon.StartAttack();
        }
        public void StopAttack()
        {
            if (_weaponMachine._currentWeapon != null)
                _weaponMachine._currentWeapon.StopAttack();
        }
        public void Reload()
        {
            if (_weaponMachine._currentWeapon != null)
                _weaponMachine._currentWeapon.Reload();
        }

        public void ChangeWeapon(int weaponNumber)
        {
            if (_weapons.Count >= weaponNumber)
                _weaponMachine.ChangeWeapon(_weapons[weaponNumber - 1].GetType());
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("You died. What a pity.");
            //animate death
            //restart level
        }
    }
}