using PlayerSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private WeaponTypes _resourceType;
    [Range(1, 250)][SerializeField] private int _count;

    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
            switch (_resourceType)
            {
                case WeaponTypes.Pistol:
                    other.gameObject.GetComponent<PlayerCombat>().AddResources( typeof(SimplePistol), _count);
                    break;
                case WeaponTypes.MachineGun:
                    other.gameObject.GetComponent<PlayerCombat>().AddResources(typeof(MachineGun), _count);
                    break;
               /* case WeaponTypes.Laser:
                    other.gameObject.GetComponent<PlayerCombat>().AddResources(typeof(), _count);
                    break;*/
            }
            
    } 
}
