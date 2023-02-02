using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    private Dictionary<Type, AWeapon> _weapons;
    private AWeapon _currentWeapon;

    public WeaponStateMachine()
    {
        //подписка update на инпут как минимум 
    }

    private void InitStates(List<AWeapon> weaponStates)
    {
        _weapons = new Dictionary<Type, AWeapon>();
        foreach(AWeapon weapon in weaponStates)
        {
            _weapons.Add(weapon.GetType(), weapon);
        }
    }

    public void ChangeState(Type typeOfNextWeapon)
    {
        _currentWeapon = _weapons[typeOfNextWeapon];
    }

    private void Update()
    {
    }
}
