using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace CosmoBlast.Weapons
{
    public sealed class WeaponFactory
    {
        private readonly ObjectPool<GameObject> _defaultBulletPool;

        public WeaponFactory(ObjectPool<GameObject> defaultBulletPool)
        {
            _defaultBulletPool = defaultBulletPool != null
                ? defaultBulletPool
                : throw new ArgumentNullException(nameof(defaultBulletPool));
        }

        public PistolWeapon CreateDefaultWeapon(Transform firePoint, string layerName = Layers.PlayerProjectile) => new PistolWeapon(firePoint, _defaultBulletPool, layerName);

        public PistolWeapon CreatePistolWeapon(Transform firePoint, string layerName = Layers.PlayerProjectile) => new PistolWeapon(firePoint, _defaultBulletPool, layerName);

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
}
