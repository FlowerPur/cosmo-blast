using UnityEngine;

public sealed class WeaponPickup : MonoBehaviour
{
    private Weapon _weapon;

    public void Initialize(Weapon weapon) => _weapon = weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out PlayerAttack playerAttack)) return;

        playerAttack.SetWeapon(_weapon);

        Destroy(gameObject);
    }
}
