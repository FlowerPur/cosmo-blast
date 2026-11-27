using UnityEngine;

namespace CosmoBlast.Weapons.Projectile
{
    public sealed class LinearProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update() => transform.position += _speed * Time.deltaTime * transform.up;
    }
}
