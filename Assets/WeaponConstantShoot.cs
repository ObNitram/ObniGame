using System;
using Main.Weapon;
using Main.Weapon.SO_Weapon;
using UnityEngine;

public class WeaponConstantShoot : MonoBehaviour
{
    [SerializeField] private RangeWeapon _rangeWeapon;
    [SerializeField] private WeaponSO _weaponSO;

    private void OnEnable()
    {
        _rangeWeapon.WeaponSO = _weaponSO;
        _rangeWeapon.StartShoot();
    }

    private void Update()
    {
        _rangeWeapon.StartShoot();
    }

    private void OnDisable()
    {
        _rangeWeapon.StopShoot();
    }
}
