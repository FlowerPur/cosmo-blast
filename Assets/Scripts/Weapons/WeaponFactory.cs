using System;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class WeaponFactory
{
    public PistolWeapon CreateDefaultWeapon(Transform firePoint)
    {
        return new PistolWeapon(firePoint, null);
    }

    public PistolWeapon CreatePistolWeapon(Transform firePoint)
    {
        return new PistolWeapon(firePoint, null);
    }

    public AssaultRifleWeapon CreateAssaultRifleWeapon(Transform firePoint)
    {
        return new AssaultRifleWeapon(firePoint, null);
    }

    public Weapon CreateRandomWeapon(Transform firePoint)
    {
        int index = Random.Range(0, 2);

        return index switch
        {
            0 => CreatePistolWeapon(firePoint),
            1 => CreateAssaultRifleWeapon(firePoint),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };
    }
}
