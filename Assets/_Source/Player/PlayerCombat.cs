using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;

namespace PlayerSystems
{
    public class PlayerCombat : MonoBehaviour, IDamagable
    {
        [SerializeField] private WeaponStateMachine _weaponMachine;

        [SerializeField] private AWeapon _weapon1;
        [SerializeField] private AWeapon _weapon2;

        private void Start()
        {
            //�������� �� �����

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

        private void Die()
        {
            //animate death
            //restart level
        }

        public void Damage()
        {
            //������� �� ����
        }

        public void Annihilate()
        {
            //�������� ������ � ���������� ������
        }
    }
}