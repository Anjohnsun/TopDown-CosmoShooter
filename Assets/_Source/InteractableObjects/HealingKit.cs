using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingKit : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _healedHP;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer == (_playerLayer | (1 << other.gameObject.layer)))
        {
            //delay? + sound?
            other.gameObject.GetComponentInParent<HealthModule>().Heal(_healedHP);

            Destroy(gameObject);
        }
    }
}
