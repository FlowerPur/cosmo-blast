using System;
using UnityEngine;
using VContainer;

public sealed class EnemyAttack : MonoBehaviour
{
    [SerializeField] private WeaponType _weaponType;

    private WeaponFactory _weaponFactory;

    private Weapon _weapon;

    [Inject]
    public void Construct(WeaponFactory weaponFactory)
    {
        _weaponFactory = weaponFactory;

        _weapon = _weaponType switch
        {
            WeaponType.PistolWeapon => _weaponFactory.CreatePistolWeapon(transform, Layers.EnemyProjectile),
            WeaponType.AssaultRifle => _weaponFactory.CreateAssaultRifleWeapon(transform),
            _ => throw new ArgumentOutOfRangeException(nameof(_weaponType))
        };
    }

    private void Start() => _weapon.StartAttack();

    private void Update() => _weapon.Update();
}
