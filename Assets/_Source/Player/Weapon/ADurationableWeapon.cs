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


    public override void StartAction()
    {
        _isShooting = true;
    }

    private void Update()
    {
        if (_isShooting)
        {
            _timeToShot -= Time.deltaTime;
            if (_timeToShot <= 0)
            {
                if (_bulletsInMagazine > 0)
                {
                    Ray ray = new Ray(_shootPoint.position, _shootPoint.forward * _shootDistance);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.transform.TryGetComponent<HealthModule>(out _enemyHealthModule)) _enemyHealthModule.GetDamage(_damage);
                        Instantiate(_hitEffect, hit.point, new Quaternion());
                        _bulletsInMagazine--;
                    }
                }
                _timeToShot = _shootDelay;
            }
        }
    }

    public override void StopAction()
    {
        _isShooting = false;
    }
}
