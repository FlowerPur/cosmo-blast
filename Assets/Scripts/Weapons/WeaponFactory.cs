using System;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class WeaponFactory
{
    private readonly GameObject _defaultBulletPrefab;

    public WeaponFactory(GameObject defaultBulletPrefab)
    {
        _defaultBulletPrefab = defaultBulletPrefab != null
            ? defaultBulletPrefab
            : throw new ArgumentNullException(nameof(defaultBulletPrefab));
    }

    public PistolWeapon CreateDefaultWeapon(Transform firePoint, string layerName = Layers.PlayerProjectile) => new PistolWeapon(firePoint, _defaultBulletPrefab, layerName);

    public PistolWeapon CreatePistolWeapon(Transform firePoint, string layerName = Layers.PlayerProjectile) => new PistolWeapon(firePoint, _defaultBulletPrefab, layerName);

    public AssaultRifleWeapon CreateAssaultRifleWeapon(Transform firePoint) => new AssaultRifleWeapon(firePoint, null);

    public Weapon CreateRandomWeapon(Transform firePoint, string layerName = Layers.PlayerProjectile)
    {
        int index = Random.Range(0, 2);

        return index switch
        {
            0 => CreatePistolWeapon(firePoint, layerName),
            1 => CreateAssaultRifleWeapon(firePoint),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };
    }
}
