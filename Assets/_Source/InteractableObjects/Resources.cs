using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private WeaponTypes _resourceType;
    [SerializeField] private int _count;

    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (_playerLayer == (_playerLayer | (1 << other.gameObject.layer)))
        {
            //delay? + sound?
            switch (_resourceType)
            {
                case WeaponTypes.Pistol:
                    other.gameObject.GetComponentInParent<PlayerCombat>().AddResources(typeof(SimplePistol), _count);
                    break;
                case WeaponTypes.MachineGun:
                    other.gameObject.GetComponentInParent<PlayerCombat>().AddResources(typeof(MachineGun), _count);
                    break;
                case WeaponTypes.Laser:
                    //other.gameObject.GetComponentInParent<PlayerCombat>().AddResources(typeof(), _count);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
