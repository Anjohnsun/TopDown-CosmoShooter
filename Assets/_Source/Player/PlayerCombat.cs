using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;

namespace PlayerSystems
{
    public class PlayerCombat : MonoBehaviour, IDamagable, IPausable
    {
        private WeaponStateMachine _weaponMachine;

        [SerializeField] private List<AWeapon> _weapons;

        private PlayerInput _playerInput;

        GameStates IPausable.CurrentGameState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        delegate void UsingWeapon();
        private UsingWeapon ChoseWeap1;
        private UsingWeapon ChoseWeap2;    
        private UsingWeapon ChoseWeap3;
        private UsingWeapon ReloadD;
        private UsingWeapon StartActionD;
        private UsingWeapon StopActionD;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _playerInput.Player.Attack.started += context => StartActionD();
            _playerInput.Player.Attack.canceled += context => StopActionD();

            _playerInput.Player.Reload.started += context => ReloadD();

            //_playerInput.Player.Weapon1.started += context => _weaponMachine.ChangeState(typeof(SimplePistol));
            //_playerInput.Player.Weapon2.started += context => _weaponMachine.ChangeState(typeof(MachineGun));
            //_playerInput.Player.Weapon3.started += context => _weaponMachine.ChangeState(typeof(Laser));
            _playerInput.Player.Weapon3.started += context => ChoseWeap1();
            _playerInput.Player.Weapon3.started += context => ChoseWeap2();
            _playerInput.Player.Weapon3.started += context => ChoseWeap3();

            _weaponMachine = new WeaponStateMachine();

            LoadSaves();
            SubscribeInput(true);
        }

        private void LoadSaves()
        {
            //логика загрузки из префаба
            //AddNewWeapon(_weapons[1], 25);
        }

        private void SubscribeInput(bool conf)
        {
            if (conf)
            {
                ReloadD += Reload;
                StartActionD += StartAction;
                StopActionD += StopAction;

                ChoseWeap1 += () => _weaponMachine.ChangeState(typeof(SimplePistol));
                ChoseWeap2 += () => _weaponMachine.ChangeState(typeof(MachineGun));
                ChoseWeap3 += () => _weaponMachine.ChangeState(typeof(Laser));
            } else
            {
                ReloadD -= Reload;
                StartActionD -= StartAction;
                StopActionD -= StopAction;

                ChoseWeap1 -= () => _weaponMachine.ChangeState(typeof(SimplePistol));
                ChoseWeap2 -= () => _weaponMachine.ChangeState(typeof(MachineGun));
                ChoseWeap3 -= () => _weaponMachine.ChangeState(typeof(Laser));
            }
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
            if (_weaponMachine.CurrentWeapon is AReloadableWeapon)
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
                if (weapon.GetType() == weaponType)
                    if (weapon is AReloadableWeapon)
                    {
                        AReloadableWeapon weap = (AReloadableWeapon)weapon;
                        weap.AddBullets(number);
                    }
            }
        }

        public void OnGameStateChanged(GameStates newGameState)
        {
            switch (newGameState)
            {
                case GameStates.Paused:
                    SubscribeInput(false);
                    break;
                case GameStates.Playing:
                    SubscribeInput(true);
                    break;
            }
        }

    }
}