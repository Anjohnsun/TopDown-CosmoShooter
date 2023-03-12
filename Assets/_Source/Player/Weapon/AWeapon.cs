using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AWeapon : AWeaponBase
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _shootDistance;

    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected GameObject _hitEffect;
    [SerializeField] protected Transform _shootPoint;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public virtual void StartAction() { }
    public virtual void StopAction() { }
}
