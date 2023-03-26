using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    private Dictionary<Type, AWeapon> _weapons;
    private AWeapon _currentWeapon;
    public AWeapon CurrentWeapon
    {
        get => _currentWeapon;
        private set => _currentWeapon = value;
    }
    public WeaponStateMachine(List<AWeapon> startWeapons)
    {
        InitStates(startWeapons);
    }

    private void InitStates(List<AWeapon> weaponStates)
    {
        _weapons = new Dictionary<Type, AWeapon>();
        foreach(AWeapon weapon in weaponStates)
        {
            _weapons.Add(weapon.GetType(), weapon);
        }

        //потом удалить
        ChangeState(typeof(SimplePistol));
    }

    public void ChangeState(Type typeOfNextWeapon)
    {
        //необходимо обсудить способ смены орудия
        _currentWeapon = _weapons[typeOfNextWeapon];
    }

    public void AddNewState(AWeapon newWeapon)
    {
        _weapons.Add(newWeapon.GetType(), newWeapon);
    }
}
