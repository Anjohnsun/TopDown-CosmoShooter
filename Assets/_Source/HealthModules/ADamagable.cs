using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem
{
    public interface ADamagable
    {
        public void Damage();
        public void Annihilate();
    }
}