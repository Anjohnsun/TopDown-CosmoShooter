using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public int Damage { get; }
    public void Attack();

}
