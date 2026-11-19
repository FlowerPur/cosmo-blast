using System.Collections;
using UnityEngine;

public sealed class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

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

            Instantiate(_prefab, transform.position, Quaternion.identity).GetComponent<WeaponPickup>().Initialize(GetRandomWeapon());
        }
    }

    private Weapon GetRandomWeapon()
    {
        return Random.Range(0, 2) switch
        {
            0 => new PistolWeapon(null, null),
            1 => new AssaultRifleWeapon(null, null),
            _ => throw new System.ArgumentOutOfRangeException()
        };
    }
}
