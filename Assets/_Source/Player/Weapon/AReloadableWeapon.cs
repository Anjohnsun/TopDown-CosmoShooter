using System;
using UnityEngine;

[Serializable]
public abstract class AReloadableWeapon : AWeapon
{
    [SerializeField] protected int _magazineSize;
    [SerializeField] protected int _bulletsInMagazine;
    [SerializeField] protected int _extraBulletNumber;

    protected int BulletInMagazine
    {
        get => _bulletsInMagazine;
        set
        {
            _bulletsInMagazine = value;
            _wInfoRenderer.RefreshInfo();
        }
    }

    public int BulletsInMagazine => _bulletsInMagazine;
    public int ExtraBulletNumber => _extraBulletNumber;

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
        _wInfoRenderer.RefreshInfo();
    }

    public virtual void AddBullets(int bulletNumber)
    {
        if (bulletNumber <= 0)
            return;
        _extraBulletNumber += bulletNumber;
        _wInfoRenderer.RefreshInfo();
    }

    public override void Enter()
    {
        base.Enter();
        _wInfoRenderer.ChangeWeapon(this);
    }
}
