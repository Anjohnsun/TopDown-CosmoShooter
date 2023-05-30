using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class BulletScript : MonoBehaviour, IPausable
{
    
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _dealDamage;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _rocketLife = 5;
    private Transform _player;
    private bool _ifPlayerFound = false;
    private bool _onPause = false;

    GameStates IPausable.CurrentGameState { get; set ; }

    private void Start()
    {
        GameStateMachine.StateChanged += OnGameStateChanged;
    }

    private void Update()
    {
        if (_onPause == false)
        {
            _rocketLife -= Time.deltaTime;
            if (_rocketLife <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameStateMachine.StateChanged -= OnGameStateChanged;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 7)
        {
           
        }
        
    }

    public void OnGameStateChanged(GameStates newGameState)
    {

    }
}
