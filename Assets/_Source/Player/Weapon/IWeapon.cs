using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public int Damage { get; }
    public float ShootDistance { get; }
    public GameObject ShootEffect { get; }
    public GameObject HitEffect { get; }
    public Transform ShootPoint { get; }
    public void Attack();
    public void StopAttack();

}
