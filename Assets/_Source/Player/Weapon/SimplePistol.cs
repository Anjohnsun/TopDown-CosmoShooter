using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;

public class SimplePistol : AReloadableWeapon
{
    private HealthModule _enemyHealthModule;
    public override void StartAction()
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
    }
}
