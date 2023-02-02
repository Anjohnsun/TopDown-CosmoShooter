using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObjects/BulletSO", order = 1)]
public class BulletSO : ScriptableObject
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _dealDamage;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _shootPoint;
}
