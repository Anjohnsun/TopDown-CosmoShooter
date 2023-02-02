using System;
using UnityEngine;

[Serializable]
public abstract class AReloadableWeapon : AWeapon
{
    [SerializeField] protected int _magazineSize;
    [SerializeField] protected int _bulletsInMagazine;
    [SerializeField] protected int _extraBulletNumber;

    public override void Reload()
    {
        if (_extraBulletNumber > (_magazineSize - _bulletsInMagazine))
        {
            _extraBulletNumber -= _magazineSize - _bulletsInMagazine;
            _bulletsInMagazine = _magazineSize;
        }
        else
        {
            _bulletsInMagazine += _extraBulletNumber;
            _extraBulletNumber = 0;
        }
    }
}
