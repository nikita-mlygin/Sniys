using UnityEngine;

public class ReloadWeaponComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<Reload>(out var reload))
        {
            if (reload.ReloadTime < Time.time)
            {
                GameObject.Destroy(projectile);
                return false;
            }
        }

        return true;
    }
}