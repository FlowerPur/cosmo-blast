using UnityEngine;

public class AssaultRifleWeapon : Weapon
{
    private Transform _firePoint;
    private GameObject _bulletPrefab;

    private float t;

    public AssaultRifleWeapon(Transform firePoint, GameObject bulletPrefab)
    {
        _firePoint = firePoint;
        _bulletPrefab = bulletPrefab;
    }

    public override void Update()
    {
        base.Update();

        t += Time.deltaTime;

        if (t >= 0.75f)
        {
            Debug.Log("Assault rifle shooting");
            t = 0;
        }
    }
}
