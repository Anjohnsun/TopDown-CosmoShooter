using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimForBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _rocketLife = 5;
    private Transform _target;
    private bool _onPause;

    private void Update()
    {

        if (_onPause == false)
        {
            transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
            _rocketLife -= Time.deltaTime;
            if (_rocketLife <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && _onPause == false)
        {
            Debug.Log("dsasd");
            _target = other.gameObject.transform;
            Vector3 direction = _target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(direction);
            gameObject.transform.rotation = look;
        }
            

    }
}
