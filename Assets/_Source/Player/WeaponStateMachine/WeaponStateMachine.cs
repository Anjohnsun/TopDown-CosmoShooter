using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    private Dictionary<Type, WeaponBase> _weapons;
    private WeaponBase _currentWeapon;

    public WeaponStateMachine()
    {
        //подписка update на инпут как минимум 
        InitStates();
    }

    private void InitStates()
    {
        _weapons = new Dictionary<Type, WeaponBase>();
        //add simple gun
    }

    public void ChangeState(Type typeOfNextWeapon)
    {
        _currentWeapon = _weapons[typeOfNextWeapon];
    }

    private void Update()
    {
        _currentWeapon.Update();
    }
}
