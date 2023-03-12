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

        [SerializeField] private WeaponStateMachine _weaponMachine;

        [SerializeField] private AWeapon _weapon1;
        [SerializeField] private AWeapon _weapon2;

        private void Start()
        {
            //подписка на инпут

            _weaponMachine = new WeaponStateMachine(new List<AWeapon>() { _weapon1, _weapon2});
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                StartAction();
            if (Input.GetKeyUp(KeyCode.Mouse0))
                StopAction();
            if (Input.GetKeyDown(KeyCode.R))
                Reload();
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _weaponMachine.ChangeState(typeof(SimplePistol));
            if (Input.GetKeyDown(KeyCode.Alpha2))
                _weaponMachine.ChangeState(typeof(MachineGun));
        }

        public void StartAction()
        {
            _weaponMachine.CurrentWeapon.StartAction();
        }

        public void StopAction()
        {
            _weaponMachine.CurrentWeapon.StopAction();
        }

        public void Reload()
        {
            if(_weaponMachine.CurrentWeapon is AReloadableWeapon)
            {
                AReloadableWeapon weapon = (AReloadableWeapon)_weaponMachine.CurrentWeapon;
                weapon.Reload();
            }
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