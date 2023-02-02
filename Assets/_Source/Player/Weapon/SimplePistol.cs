using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePistol : AReloadableWeapon
{
    public void Attack()
    {
        if (_bulletsInMagazine > 0)
        {
            Ray ray = new Ray(_shootPoint.position, _shootPoint.forward * _shootDistance);
            Ray ray1 = ray;
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //если попал в IDamagable, вызвать GetDamage(_damage);
                Instantiate(_hitEffect, hit.point, new Quaternion());
            }
        }
    }
}
