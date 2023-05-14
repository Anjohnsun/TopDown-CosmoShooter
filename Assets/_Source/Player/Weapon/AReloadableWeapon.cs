using System;
using UnityEngine;

[Serializable]
public abstract class AReloadableWeapon : AWeapon
{
    [SerializeField] protected int _magazineSize;
    [SerializeField] protected int _bulletsInMagazine;
    [SerializeField] private int _extraBulletNumber;

    public virtual void Reload()
    {
        if (_bulletsInMagazine < _magazineSize)
        {
            if (_extraBulletNumber >= _magazineSize - _bulletsInMagazine)
            {
                _extraBulletNumber -= _magazineSize - _bulletsInMagazine;
                _bulletsInMagazine = _magazineSize;
            }
            else if (_extraBulletNumber == 0)
            {
                //empty sound
            }
            else
            {
                _bulletsInMagazine += _extraBulletNumber;
                _extraBulletNumber = 0;
            }
        }
    }

    public virtual void AddBullets(int bulletNumber)
    {
        if (bulletNumber <= 0)
            return;
        _extraBulletNumber += bulletNumber;
    }
}
