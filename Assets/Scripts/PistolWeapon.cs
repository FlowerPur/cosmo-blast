using UnityEngine;

public class PistolWeapon : Weapon
{
    private Transform _firePoint;
    private GameObject _bulletPrefab;

    private float t;

    public PistolWeapon(Transform firePoint, GameObject bulletPrefab)
    {
        _firePoint = firePoint;
        _bulletPrefab = bulletPrefab;
    }

    public override void Update()
    {
        base.Update();

        t += Time.deltaTime;

        if (t >= 3f)
        {
            Debug.Log("Pistol shooting");
            t = 0;
        }
    }
}
