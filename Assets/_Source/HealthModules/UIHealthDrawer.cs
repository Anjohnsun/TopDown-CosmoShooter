using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class UIHealthDrawer : MonoBehaviour
    {
        [SerializeField] private Image _hpBarImage;

        public void InitHPbar(int maxHp, int currentHp)
        {
            //������ ���������� ������� �������
            //������� ���������� ���-�� ��
        }

        public void Refresh(int currentHp)
        {
            //�������� ��� ���, ��� ��� ������� �������
            //������� ���������� ���-�� ��
        }
    }
}