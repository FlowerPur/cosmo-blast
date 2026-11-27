using UnityEngine;
using VContainer;
using VContainer.Unity;
using CosmoBlast.Player;
using CosmoBlast.Enemy;
using CosmoBlast.Weapons;

namespace CosmoBlast
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameObject _defaultBulletPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(new WeaponFactory(_defaultBulletPrefab));

            builder.RegisterComponentInHierarchy<PlayerAttack>();
            builder.RegisterComponentInHierarchy<PickupSpawner>();
            builder.RegisterComponentInHierarchy<EnemyAttack>();
        }
    }
}
