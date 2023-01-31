using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReloadableWeapon : IWeapon
{
    public int MagazineSize { get; }
    public int BulletsInMagazine { get; }
    public int ExtraBulletNumber { get; }

    public void Reload();
}
