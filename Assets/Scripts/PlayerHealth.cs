using System;

public sealed class PlayerHealth : Health
{
    public event Action Died;

    protected override void Die()
    {
        throw new NotImplementedException();
    }
}
