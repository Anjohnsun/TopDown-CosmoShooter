using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReloadableWeapon : IWeapon
{
    public int MagazineSize => MagazineSize;
    public int BulletsInMagazine => BulletsInMagazine;
    public int BulletNumber { get; }

    public void Reload();
}
