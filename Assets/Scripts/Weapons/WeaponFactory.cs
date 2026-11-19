using System;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class WeaponFactory
{
    private readonly Transform _firePoint;

    public WeaponFactory(Transform firePoint)
    {
        _firePoint = firePoint;
    }

    public PistolWeapon CreateDefaultWeapon()
    {
        return new PistolWeapon(_firePoint, null);
    }

    public PistolWeapon CreatePistolWeapon()
    {
        return new PistolWeapon(_firePoint, null);
    }

    public AssaultRifleWeapon CreateAssaultRifleWeapon()
    {
        return new AssaultRifleWeapon(_firePoint, null);
    }

    public Weapon CreateRandomWeapon()
    {
        int index = Random.Range(0, 2);

        return index switch
        {
            0 => CreatePistolWeapon(),
            1 => CreateAssaultRifleWeapon(),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };
    }
}
