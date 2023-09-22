using UnityEngine;

public class MeleeAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<MeleeAttack>(out var component))
        {
            return true;
        }

        return true;
    }
}