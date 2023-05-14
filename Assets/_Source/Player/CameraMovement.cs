using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using PlayerSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart _cameraCart;
    [SerializeField] private float _rotationTime;

    [SerializeField] private Transform _cameraTrack;
    [SerializeField] private Transform _objectToFollow;
    [SerializeField] private float _followIntensity;

    private float CameraPosition
    {
        get => _cameraCart.m_Position;
        set => _cameraCart.m_Position = value;
    }

    public void RotateCamera(bool leftWay)
    {
        if (CameraPosition % 1 == 0)
        {
            if (leftWay)
                DOTween.To(() => CameraPosition, (x) => CameraPosition = x,
        CameraPosition - 1, _rotationTime).SetEase(Ease.OutQuint);
            if (!leftWay)
                DOTween.To(() => CameraPosition, (x) => CameraPosition = x,
        CameraPosition + 1, _rotationTime).SetEase(Ease.OutQuint);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCamera(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCamera(false);
        }

        _cameraTrack.position = Vector3.Lerp(
            _cameraTrack.position, 
            new Vector3(_objectToFollow.position.x, _cameraTrack.position.y, _objectToFollow.position.z),
            _followIntensity);
    }
}
