using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;
using DG.Tweening;
using Unity.VisualScripting;

public class Container : ADamagable
{
    [SerializeField] private List<Product> _productsInside;
    [SerializeField] private AnimationCurve _sizeChangeCurve;
    [SerializeField] private GameObject _deathParticle;

    public override void Annihilate()
    {
        foreach(Product product in _productsInside)
        {
            for(int i = 0; i < product._count; i++)
            {
                Instantiate(product._productPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 0, UnityEngine.Random.Range(-0.5f, 0.5f)), new Quaternion());
                //звук разрушения
            }
        }

        // particle
        if (_deathParticle != null) Instantiate(_deathParticle, transform.position, new Quaternion());

        //dissolving
        Destroy(gameObject);
    }

    public override void Damage()
    {
        Debug.Log("damaged");
        transform.DOScale( new Vector3(1, 1, 1), 0.2f).SetEase(_sizeChangeCurve);
        //звук поломки
    }
}

[Serializable]
public class Product
{
    [SerializeField] public GameObject _productPrefab;
    [SerializeField] public int _count;
}
