using UnityEngine;

namespace CosmoBlast.Player
{
    public sealed class PlayerHealth : Health
    {
        // public event Action Died;

        protected override void Die()
        {
            Debug.Log("Player died!");
        }
    }
}