using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AWeapon : MonoBehaviour, IWeaponState
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _shootDistance;

    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected GameObject _hitEffect;
    [SerializeField] protected Transform _shootPoint;

    protected bool _isActive = false;

    public void Enter()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }

    public abstract void StartAttack();
    public abstract void StopAttack();
    public abstract void Reload();

}
