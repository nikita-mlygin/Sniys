using UnityEngine;

public class MeleeAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<MeleeAttack>(out var component))
        {
            if (component.StartTime + component.DieTimer < Time.time)
            {
                Object.Destroy(projectile);

                return false;
            }

            return true;
        }

        return true;
    }
}