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


public class SimpleWeaponState : WeaponBase
{
    private Animator _animator;
    public SimpleWeaponState(WeaponStateMachine owner, Animator animator) : base(owner)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        //анимация появления
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
        //анимация исчезания
    }
}