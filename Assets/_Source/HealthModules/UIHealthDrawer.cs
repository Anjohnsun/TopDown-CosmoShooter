using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class UIHealthDrawer : MonoBehaviour
    {
        [SerializeField] private Image _hpBarImage;
        private int _maxHp;

        public void InitHPbar(int maxHp, int currentHp)
        {
            _maxHp = maxHp;
            _hpBarImage.fillAmount = currentHp;
        }

        public void Refresh(int currentHp)
        {
            _hpBarImage.fillAmount = currentHp / _maxHp;
        }
    }
}