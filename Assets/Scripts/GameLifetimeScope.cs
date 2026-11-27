using UnityEngine;
using VContainer;
using VContainer.Unity;
using CosmoBlast.Player;
using CosmoBlast.Enemy;
using CosmoBlast.Weapons;
using UnityEngine.Pool;
using CosmoBlast.Weapons.Projectile;

namespace CosmoBlast
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameObject _defaultBulletPrefab;
        private ObjectPool<GameObject> _pool;

        protected override void Configure(IContainerBuilder builder)
        {
            _pool = new ObjectPool<GameObject>(
                createFunc: () => CreateProjectile(),
                actionOnGet: bullet => bullet.gameObject.SetActive(true),
                actionOnRelease: bullet => bullet.gameObject.SetActive(false),
                actionOnDestroy: bullet => Destroy(bullet.gameObject),
                collectionCheck: true,
                defaultCapacity: 20,
                maxSize: 20
            );
            builder.RegisterInstance(new WeaponFactory(_pool));

            builder.RegisterComponentInHierarchy<PlayerAttack>();
            builder.RegisterComponentInHierarchy<PickupSpawner>();
            builder.RegisterComponentInHierarchy<EnemyAttack>();
        }

        private GameObject CreateProjectile()
        {
            GameObject projectile = Instantiate(_defaultBulletPrefab);
            projectile.GetComponent<ProjectileDamage>().Initialize(_pool);
            return projectile;
        }
    }
}
