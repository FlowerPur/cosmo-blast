using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Weapon _defaultWeapon;
    private Weapon _currentWeapon;

    private Weapon _assaultRifleWeapon;

    [SerializeField] private bool _testAssaultRifle;

    private void Start()
    {
        _defaultWeapon = new PistolWeapon(transform, null);
        _assaultRifleWeapon = new AssaultRifleWeapon(transform, null);

        if (_defaultWeapon == null) return;
        _currentWeapon = _defaultWeapon;
        _currentWeapon.StartAttack();
    }

    private void Update()
    {
        if (_testAssaultRifle)
        {
            SetWeapon(_assaultRifleWeapon);
        }
        else
        {
            SetWeapon(_defaultWeapon);
        }
        _currentWeapon?.Update();
    }

    public void SetWeapon(Weapon weapon)
    {
        _currentWeapon?.StopAttack();

        _currentWeapon = weapon;

        _currentWeapon.StartAttack();
    }
}
