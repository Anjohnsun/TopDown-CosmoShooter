using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePistol : AReloadableWeapon
{
    public override void StartAttack()
    {
        if (_bulletsInMagazine > 0)
        {
            Ray ray = new Ray(_shootPoint.position, _shootPoint.forward * _shootDistance);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //если попал в IDamagable, вызвать GetDamage(_damage);
                Instantiate(_hitEffect, hit.point, new Quaternion());
            }
            _bulletsInMagazine--;
        }
    }

    public override void StopAttack()
    {
        throw new System.NotImplementedException();
    }
}
