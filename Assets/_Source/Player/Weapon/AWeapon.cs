using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[Serializable]
public abstract class AWeapon : AWeaponBase
{
    [SerializeField] protected int _damage;

    [SerializeField] protected GameObject _shootEffect;
    [SerializeField] protected GameObject _hitEffect;
    [SerializeField] protected Transform _shootPoint;

    [SerializeField] protected List<LayerMask> _shootableLayers;

    [SerializeField] protected WeaponInfoRenderer _wInfoRenderer;
    [SerializeField] protected Sprite _weaponLogo;
    public Sprite WeaponLogo => _weaponLogo;

    [SerializeField] Material mat;

    public override void Enter()
    {
        Debug.Log("Enter");
        base.Enter();

        mat.DOFloat(0 ,"_Dissolve", 0.2f);
    }

    public override void Exit()
    {
        base.Exit();
        mat.DOFloat(1, "_Dissolve", 0.2f);
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
