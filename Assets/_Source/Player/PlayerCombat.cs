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

            _playerInput.Player.Weapon1.started += context => _weaponMachine.ChangeState(_weapons[0].GetType());
            _playerInput.Player.Weapon2.started += context => _weaponMachine.ChangeState(_weapons[1].GetType());
            _playerInput.Player.Weapon3.started += context => _weaponMachine.ChangeState(_weapons[2].GetType());
            _playerInput.Player.Weapon4.started += context => _weaponMachine.ChangeState(_weapons[3].GetType());

            _weaponMachine = new WeaponStateMachine(new List<AWeapon>() {_weapons[0], _weapons[1]}); //временно, заменить на загрузку сохранени€
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
            //реакци€ на урон
        }

        public void Annihilate()
        {
            //анимаци€ смерти и перезапуск уровн€
        }

        public void AddNewWeapon(AWeapon newWeapon)
        {
            _weaponMachine.AddNewState(newWeapon);
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