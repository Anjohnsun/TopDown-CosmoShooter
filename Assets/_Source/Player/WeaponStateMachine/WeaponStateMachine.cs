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

    public WeaponStateMachine()
    {
        InitStates();
    }

    private void InitStates()
    {
        _weapons = new Dictionary<Type, AWeapon>();
    }

    public void ChangeState(Type typeOfNextWeapon)
    {
        _currentWeapon = _weapons[typeOfNextWeapon];
    }

    public void AddNewState(AWeapon newWeapon)
    {
        _weapons.Add(newWeapon.GetType(), newWeapon);
    }
}
