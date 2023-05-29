using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;

namespace PlayerSystems
{
    public class PlayerCombat : MonoBehaviour, IDamagable
    {
        private WeaponStateMachine _weaponMachine;

        [SerializeField] private List<AWeapon> _weapons;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _playerInput.Player.Attack.started += context => StartAction();
            _playerInput.Player.Attack.canceled += context => StopAction();

            _playerInput.Player.Reload.started += context => Reload();

            _playerInput.Player.Weapon1.started += context => _weaponMachine.ChangeState(typeof(SimplePistol));
            _playerInput.Player.Weapon2.started += context => _weaponMachine.ChangeState(typeof(MachineGun));
            _playerInput.Player.Weapon3.started += context => _weaponMachine.ChangeState(typeof(Laser));
            //_playerInput.Player.Weapon4.started += context => _weaponMachine.ChangeState(typeof(SimplePistol));

            _weaponMachine = new WeaponStateMachine();
            LoadSaves();
        }

        private void LoadSaves()
        {
            //логика загрузки из префаба
            //AddNewWeapon(_weapons[1], 25);
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


        public void Damage()
        {
            //реакция на урон
        }

        public void Annihilate()
        {
            //анимация смерти и перезапуск уровня
        }

        public void AddNewWeapon(AWeapon newWeapon, int StartBullets)
        {
            _weaponMachine.AddNewState(newWeapon);
            AddResources(newWeapon.GetType(), StartBullets);
        }

        public void AddResources(Type weaponType, int number)
        {
            foreach (AWeapon weapon in _weapons)
            {
                if(weapon.GetType() == weaponType)
                    if(weapon is AReloadableWeapon)
                    {
                        AReloadableWeapon weap = (AReloadableWeapon)weapon;
                        weap.AddBullets(number);
                    }
            }
        }
    }
}