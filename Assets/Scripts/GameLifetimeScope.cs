using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(new WeaponFactory());

        builder.RegisterComponentInHierarchy<PlayerAttack>();
        builder.RegisterComponentInHierarchy<PickupSpawner>();
        builder.RegisterComponentInHierarchy<EnemyAttack>();
    }
}
