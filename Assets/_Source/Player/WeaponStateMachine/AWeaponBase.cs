using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AWeaponBase : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    public virtual void Enter() { Debug.Log("enter state"); }
    public virtual void Exit() { Debug.Log("exit state"); }
}