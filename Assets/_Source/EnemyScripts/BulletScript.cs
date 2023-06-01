using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using HealthSystem;

public class BulletScript : MonoBehaviour, IPausable
{
    
    //[SerializeField] private float _bulletSpeed;
    [SerializeField] private int _dealDamage;
    //[SerializeField] private float _rocketLife = 5;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _rocketFlying;
    private bool _onPause = false;
    HealthModule healthModule;
    GameStates IPausable.CurrentGameState { get; set ; }

    private void Start()
    {
        GameStateMachine.StateChanged += OnGameStateChanged;
        _audio.Play();
    }

    
    

    private void OnDestroy()
    {
        GameStateMachine.StateChanged -= OnGameStateChanged;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("fg");
            collision.gameObject.TryGetComponent(out healthModule);
            healthModule.GetDamage(_dealDamage);
            Destroy(gameObject);
        }
        
    }

    public void OnGameStateChanged(GameStates newGameState)
    {

    }
     
}
