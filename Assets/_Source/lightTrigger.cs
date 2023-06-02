using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _lightFollowing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            _lightFollowing.GetComponent<Animation>().Play();
            Destroy(gameObject);
        }
    }
}
