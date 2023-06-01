using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADurationableWeapon : AReloadableWeapon
{
    [SerializeField] private float _shootDelay;
    private float _timeToShot = 0;
    private bool _isShooting = false;
    private HealthModule _enemyHealthModule;

    protected RaycastHit _hit;
    protected Ray _ray;

    public override void StartAction()
    {
        _isShooting = true;
    }

    protected void Update()
    {
        if (_isShooting)
        {
            _timeToShot -= Time.deltaTime;
            if (_timeToShot <= 0)
            {
                if (_bulletsInMagazine > 0)
                {
                    _ray = new Ray(_shootPoint.position, _shootPoint.forward * 500);
                    if (Physics.Raycast(_ray, out _hit))
                    {
                        if (_hit.transform.TryGetComponent(out _enemyHealthModule) || _hit.transform.parent.TryGetComponent(out _enemyHealthModule))
                            _enemyHealthModule.GetDamage(_damage);
                        Instantiate(_hitEffect, _hit.point, new Quaternion());
                    }
                    BulletInMagazine--;
                    _audio.Play();
                }
                _timeToShot = _shootDelay;
            }
        }
    }

    public override void StopAction()
    {
        _isShooting = false;
    }

    public override void Exit()
    {
        base.Exit();
        StopAction();
    }

}
