using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AWeapon : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _shootDistance;

    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected GameObject _hitEffect;
    [SerializeField] protected Transform _shootPoint;

    public virtual void StartAttack() { }
    public virtual void StopAttack() { }
}
