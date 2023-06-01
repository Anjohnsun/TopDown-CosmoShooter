using HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADamagable : MonoBehaviour, IDamagable
{
    public virtual void Annihilate()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Damage()
    {
        throw new System.NotImplementedException();
    }
}
