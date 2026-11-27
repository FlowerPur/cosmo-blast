using System.Collections;
using UnityEngine;
using VContainer;
using CosmoBlast.Pickups;
using CosmoBlast.Weapons;

namespace CosmoBlast
{
    public sealed class PickupSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        private WeaponFactory _weaponFactory;

        [Inject]
        public void Construct(WeaponFactory weaponFactory) =>
            _weaponFactory = weaponFactory ?? throw new System.ArgumentNullException(nameof(weaponFactory));

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                float randomTime = Random.Range(3f, 8f);

                yield return new WaitForSeconds(randomTime);

                // Instantiate(_prefab, transform.position, Quaternion.identity).GetComponent<WeaponPickup>().Initialize(_weaponFactory.CreateRandomWeapon());
            }
        }
    }
}
