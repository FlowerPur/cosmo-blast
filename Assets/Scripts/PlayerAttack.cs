using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Weapon _defaultWeapon;
    private Weapon _currentWeapon;

    private void Awake()
    {
        _defaultWeapon = new PistolWeapon(transform, null);
        SetWeapon(_defaultWeapon);
    }

    private void Start() => _currentWeapon.StartAttack();

    private void Update() => _currentWeapon.Update();

    public void SetWeapon(Weapon weapon)
    {
        weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));

        if (_currentWeapon != null)
        {
            _currentWeapon.StopAttack();
            _currentWeapon.Depleted -= OnWeaponDepleted;
        }

        _currentWeapon = weapon;

        _currentWeapon.Depleted += OnWeaponDepleted;
        _currentWeapon.StartAttack();
    }

    private void OnWeaponDepleted() => SetWeapon(_defaultWeapon);
}
