using System;

public abstract class Weapon
{
    public Action Depleted;

    private bool _isAttacking;

    public void StartAttack() => _isAttacking = true;

    public void StopAttack() => _isAttacking = false;

    public virtual void Update()
    {
        if (!_isAttacking) return;
    }
}
