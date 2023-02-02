using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public delegate void _buttonClicked();
    public delegate void _axisClicked(float axisValue);

    [HideInInspector] public event _buttonClicked StartedAttack;
    [HideInInspector] public event _buttonClicked StopedAttack;
    [HideInInspector] public event _buttonClicked Interacted;

    [HideInInspector] public event _axisClicked MovedHorizontally;
    [HideInInspector] public event _axisClicked MovedVertically;

    [SerializeField] private KeyCode AttackKey;
    [SerializeField] private KeyCode InteractKey;

    private void Update()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            StartedAttack.Invoke();
        }
        if (Input.GetKeyUp(AttackKey))
        {
            StopedAttack.Invoke();
        }
        if (Input.GetKeyDown(InteractKey))
        {
            Interacted.Invoke();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            MovedHorizontally.Invoke(Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            MovedHorizontally.Invoke(Input.GetAxis("Vertical"));
        }
    }
}
