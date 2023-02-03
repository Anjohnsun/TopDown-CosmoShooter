using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    private Dictionary<Type, AWeapon> _weapons;
    public AWeapon _currentWeapon { get; private set; }

    public WeaponStateMachine()
    {
        
    }

    public void InitStates(List<AWeapon> weaponStates)
    {
        _weapons = new Dictionary<Type, AWeapon>();
        foreach(AWeapon weapon in weaponStates)
        {
            _weapons.Add(weapon.GetType(), weapon);
        }
        _currentWeapon = _weapons[weaponStates[0].GetType()];
    }

    public void ChangeWeapon(Type typeOfNextWeapon)
    {
        if (typeOfNextWeapon != _currentWeapon.GetType())
        {
            _currentWeapon.Exit();
            _currentWeapon = _weapons[typeOfNextWeapon];
            _currentWeapon.Enter();
        }
    }

}
