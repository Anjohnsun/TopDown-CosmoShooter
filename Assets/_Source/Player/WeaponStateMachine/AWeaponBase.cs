using UnityEngine;

public abstract class AWeaponBase : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    public virtual void Enter() { Debug.Log("enter state"); }
    public virtual void Exit() { Debug.Log("exit state"); }
}


/*public class SimpleWeaponState : AWeaponBase
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

    public override void Exit()
    {
        //анимация исчезания
    }
}*/