using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : ADurationableWeapon
{
    [SerializeField] private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer.enabled = false;
    }

    public override void StartAction()
    {
        base.StartAction();
        _lineRenderer.enabled = true;
    }

    private new void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        _lineRenderer.SetPosition(1, new Vector3(0, 0, _hit.distance));
    }

    public override void StopAction()
    {
        base.StopAction();
        _lineRenderer.enabled = false;
    }
}
