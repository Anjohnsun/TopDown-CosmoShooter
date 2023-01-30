using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystems
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _health;

        private void Start()
        {
            //подписка на инпут
        }

        public void Attack()
        {

        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //animate death
            //restart level
        }
    }
}