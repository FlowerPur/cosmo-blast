using System;
using UnityEngine;

namespace CosmoBlast.Weapons
{
    public sealed class PistolWeapon : Weapon
    {
        private Transform _firePoint;
        private GameObject _projectilePrefab;
        private readonly int _projectileLayer;

        private float t;

        public PistolWeapon(Transform firePoint, GameObject projectilePrefab, string layerName)
        {
            if (firePoint == null)
                throw new ArgumentNullException(nameof(firePoint));

            if (projectilePrefab == null)
                throw new ArgumentNullException(nameof(projectilePrefab));

            if (string.IsNullOrWhiteSpace(layerName))
                throw new ArgumentException("Layer name cannot be empty.", nameof(layerName));

            _firePoint = firePoint;
            _projectilePrefab = projectilePrefab;

            _projectileLayer = LayerMask.NameToLayer(layerName);

            if (_projectileLayer == -1)
                throw new ArgumentException($"Unity layer '{layerName}' is not configured.", nameof(layerName));
        }

        public override void Update()
        {
            base.Update();

            t += Time.deltaTime;

            if (t >= 3f)
            {
                Debug.Log($"Pistol shooting {_firePoint.position} {_firePoint.gameObject.name}");

                GameObject bullet = UnityEngine.Object.Instantiate(
                    _projectilePrefab,
                    _firePoint.position,
                    _firePoint.rotation);
                bullet.layer = _projectileLayer;
                if (bullet.layer == LayerMask.NameToLayer(Layers.EnemyProjectile))
                {
                    bullet.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }

                t = 0;
            }
        }
    }
}
