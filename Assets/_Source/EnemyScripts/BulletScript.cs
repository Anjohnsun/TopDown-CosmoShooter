using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class BulletScript : MonoBehaviour
{
    
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _dealDamage;
    [SerializeField] private Rigidbody _rb;
    private Transform _player;
    private bool _ifPlayerFound = false;

  
    private void Start()
    {

        _rb.AddForce(_rb.transform.forward * _bulletSpeed);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 7)
        {
            //нанесение урона тут  
        }
        
    }
}
