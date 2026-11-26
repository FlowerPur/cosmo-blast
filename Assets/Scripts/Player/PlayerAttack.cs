using System;
using UnityEngine;
using VContainer;

public sealed class PlayerAttack : MonoBehaviour
{
    private WeaponFactory _weaponFactory;
    private Weapon _defaultWeapon;
    private Weapon _currentWeapon;

    [Inject]
    public void Construct(WeaponFactory weaponFactory)
    {
        _weaponFactory = weaponFactory ?? throw new ArgumentNullException(nameof(weaponFactory));
        _defaultWeapon = _weaponFactory.CreateDefaultWeapon(transform);
    }

    private void Start() => SetWeapon(_defaultWeapon);

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
