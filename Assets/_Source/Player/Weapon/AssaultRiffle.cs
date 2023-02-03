using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRiffle : AReloadableWeapon
{
    [Header("Специфическое:")]
    [SerializeField] private float _shootDelay;
    private float _timeToNextShot;

    private bool _isShooting;

    private void Start()
    {
        _isShooting = false;
        _timeToNextShot = _shootDelay;
    }

    public override void StartAttack()
    {
        _isShooting = true;
    }

    private void Update()
    {
        if (_isShooting && _timeToNextShot <= 0)
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
            _timeToNextShot = _shootDelay;
        }
        _timeToNextShot -= Time.deltaTime;
    }

    public override void StopAttack()
    {
        _isShooting = false;
    }
}
