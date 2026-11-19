using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Transform _firePoint;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(new WeaponFactory(_firePoint));

        builder.RegisterComponentInHierarchy<PlayerAttack>();
        builder.RegisterComponentInHierarchy<PickupSpawner>();
    }
}
