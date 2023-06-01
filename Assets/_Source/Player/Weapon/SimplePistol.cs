using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;

public class SimplePistol : AReloadableWeapon
{
    public override void Enter()
    {
        base.Enter();
        _wInfoRenderer.ChangeWeapon(this);
    }
}
