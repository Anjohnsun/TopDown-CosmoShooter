using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AWeapon : MonoBehaviour, IWeaponState
{
    [Header("��������:")]
    [SerializeField] protected int _damage;
    [SerializeField] protected float _shootDistance;

    [Header("��. ������:")]
    [SerializeField] protected Transform _shootPoint;

    [Header("������:")]
    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected GameObject _hitEffect;

    protected bool _isActive = false;

    public virtual void Enter()
    {
        gameObject.SetActive(true);
    }

    public virtual void Exit()
    {
        gameObject.SetActive(false);
    }

    public abstract void StartAttack();
    public abstract void StopAttack();
    public abstract void Reload();

}
