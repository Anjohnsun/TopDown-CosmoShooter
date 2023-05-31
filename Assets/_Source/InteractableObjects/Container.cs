using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealthSystem;
using DG.Tweening;

public class Container : MonoBehaviour, IDamagable
{
    [SerializeField] private List<Product> _productsInside;
    [SerializeField] private AnimationCurve _sizeChangeCurve;

    public void Annihilate()
    {
        foreach(Product product in _productsInside)
        {
            for(int i = 0; i < product._count; i++)
            {
                Instantiate(product._productPrefab, transform.position + new Vector3(UnityEngine.Random.Range(0, 0.2f), 0, UnityEngine.Random.Range(0, 0.2f)), new Quaternion());
                //звук разрушения
            }
        }

        //dissolving
        Destroy(gameObject);
    }

    public void Damage()
    {
        transform.DOScale( 1, 0.2f).SetEase(_sizeChangeCurve);
        //звук поломки
    }
}

[Serializable]
public class Product
{
    [SerializeField] public GameObject _productPrefab;
    [SerializeField] public int _count;
}
