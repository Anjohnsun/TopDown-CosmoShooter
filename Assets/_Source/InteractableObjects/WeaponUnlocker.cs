using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystems;

public class WeaponUnlocker : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private AWeapon _weaponToUnlock;
    [SerializeField] private int _startBullets;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if ((_playerLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            other.GetComponentInParent<PlayerCombat>().AddNewWeapon(_weaponToUnlock, _startBullets);
            Destroy(gameObject);
        }
    }
}
