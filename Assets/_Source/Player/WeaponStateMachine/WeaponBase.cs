using UnityEngine;

public abstract class WeaponBase 
{
    protected WeaponStateMachine _owner;

    protected WeaponBase(WeaponStateMachine owner)
    {
        _owner = owner;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}