using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AWeaponBase : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    public virtual void Enter() { }
    public virtual void Exit() { }
}