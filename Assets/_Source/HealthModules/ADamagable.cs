using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADamagable : MonoBehaviour, IDamagable
{
    public abstract void Annihilate();

    public abstract void Damage();
}
