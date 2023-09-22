using UnityEngine;

public class DeathTimerComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<DeathTimer>(out var deathTimer))
        {
            if (deathTimer.DeathTime < Time.time)
            {
                Object.Destroy(projectile);

                return false;
            }
        }

        return true;
    }
}