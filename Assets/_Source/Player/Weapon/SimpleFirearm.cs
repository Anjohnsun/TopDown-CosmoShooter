using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFirearm : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _shootDistance;
    [SerializeField] private int _magazineSize;
    [SerializeField] private int _bulletsInMagazine;
    [SerializeField] private int _extraBulletNumber;

    [SerializeField] private GameObject _shootEffect;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Transform _shootPoint;

    public int Damage => _damage;
    public float ShootDistance => _shootDistance;
    public int MagazineSize => _magazineSize;
    public int BulletsInMagazine => _bulletsInMagazine;
    public int ExtraBulletNumber => _extraBulletNumber;
    public GameObject ShootEffect => _shootEffect;
    public GameObject HitEffect => _hitEffect;
    public Transform ShootPoint => _shootPoint;

    private Ray ray1;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Attack()
    {
        if (_bulletsInMagazine>0)
        {
            Ray ray = new Ray(_shootPoint.position, _shootPoint.forward* _shootDistance);
            ray1 = ray;
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                //если попал в IDamagable, вызвать GetDamage(_damage);
                Instantiate(_hitEffect, hit.point, new Quaternion());
                Debug.Log("poof");
            }
        }
    }

    public void Reload()
    {
    }

    public void StopAttack()
    {
    }


    //----------------------------[


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray1);
    }
}
