using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using HealthSystem;

public class BulletScript : MonoBehaviour, IPausable
{
    
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _dealDamage;
    [SerializeField] private float _rocketLife = 5;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _rocketFlying;
    private bool _onPause = false;
    HealthModule healthModule;
    GameStates IPausable.CurrentGameState { get; set ; }

    private void Start()
    {
        GameStateMachine.StateChanged += OnGameStateChanged;
        //_audio.clip = _rocketFlying;
        _audio.Play();
    }

    private void Update()
    {

        if (_onPause == false)
        {
            transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
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
            collision.gameObject.TryGetComponent(out healthModule);
            healthModule.GetDamage(_dealDamage);
        }
        
    }

    public void OnGameStateChanged(GameStates newGameState)
    {

    }
}
