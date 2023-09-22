using UnityEngine;

public class MeleeAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<MeleeAttack>(out var component))
        {
            if (component.startTime + component.dieTimer < Time.time)
            {
                Object.Destroy(projectile);

                return false;
            }

            return true;
        }

        return true;
    }
}