using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectileFactory
{
    private static IDictionary<ProjectileEnum, IProjectileCreator> creators = new Dictionary<ProjectileEnum, IProjectileCreator>();

    public static void AddCreator(ProjectileEnum type, IProjectileCreator creator)
    {
        creators.Add(type, creator);
    }

    public static bool TryGet(ProjectileEnum type, IWeapon weapon, Vector2 direction, out IProjectile projectile)
    {
        if (creators.TryGetValue(type, out var creator))
        {
            projectile = creator.CreateProjectile(weapon, direction);

            return true;
        }

        projectile = null;
        return false;
    }
}