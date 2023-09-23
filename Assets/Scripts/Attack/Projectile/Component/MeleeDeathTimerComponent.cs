using UnityEngine;

public class MeleeDeathTimerComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<DeathTimer>(out var deathTimer))
        {
            if (projectile.TryGetComponent<MeleeAttack>(out var attack))
            {
                if (deathTimer.DeathTime < Time.time)
                {
                    attack.Weapon.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }

        return true;
    }
}