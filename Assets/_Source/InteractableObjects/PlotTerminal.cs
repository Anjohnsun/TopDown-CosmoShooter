using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class PlotTerminal : ADamagable
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private AudioClip _crackSound;
    [SerializeField] private AudioClip _doorOpening;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Transform _door;

    private void Start()
    {
        _camera.Priority = -100;
    }

    public override void Annihilate()
    {
        _audio.clip = _destroySound;
        _audio.Play();
        StartCoroutine(DoorOpeningCoroutine());
    }

    public override void Damage()
    {
        _audio.Play();
    }

    private IEnumerator DoorOpeningCoroutine()
    {
        _camera.Priority = 100;
        yield return new WaitForSeconds(2f);
        _audio.clip = _doorOpening;
        _audio.Play();
        _door.DOMoveX(_door.position.x + 2f, 1.4f);
        yield return new WaitForSeconds(2f);
        _camera.Priority = -100;
    }
}
