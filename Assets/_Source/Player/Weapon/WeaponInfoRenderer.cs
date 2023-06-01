using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoRenderer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletsInMagazine;
    [SerializeField] private TextMeshProUGUI _extraBullets;
    [SerializeField] private Image _weaponLogo;

    private AReloadableWeapon _currentReloadableWeapon;

    public void ChangeWeapon(AWeapon newWeapon)
    {
        if (newWeapon is AReloadableWeapon)
        {
            _bulletsInMagazine.gameObject.SetActive(true);
            _extraBullets.gameObject.SetActive(true);

            _currentReloadableWeapon = (AReloadableWeapon)newWeapon;
            _bulletsInMagazine.text = _currentReloadableWeapon.BulletsInMagazine.ToString();
            _extraBullets.text = _currentReloadableWeapon.ExtraBulletNumber.ToString();
        }
        else
        {
            _bulletsInMagazine.gameObject.SetActive(false);
            _extraBullets.gameObject.SetActive(false);
        }
        _weaponLogo.sprite = newWeapon.WeaponLogo;
    }

    public void RefreshInfo()
    {
        if (_currentReloadableWeapon != null)
        {
            _bulletsInMagazine.text = _currentReloadableWeapon.BulletsInMagazine.ToString();
            _extraBullets.text = _currentReloadableWeapon.ExtraBulletNumber.ToString();
        }
    }
}
