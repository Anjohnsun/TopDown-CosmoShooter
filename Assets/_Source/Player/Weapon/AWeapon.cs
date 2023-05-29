using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AWeapon : AWeaponBase
{
    [SerializeField] protected int _damage;

    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected GameObject _hitEffect;
    [SerializeField] protected Transform _shootPoint;

    [SerializeField] protected List<LayerMask> _shootableLayers;

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

    protected bool IsLayerShootable(int layer)
    {
        foreach(LayerMask layerMask in _shootableLayers)
        {
            if((layerMask & 1 << layer) == 1 << layer) return true;
        }
        return false;
    }
}
