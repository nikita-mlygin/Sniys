using System;
using System.Collections;
using System.Collections.Generic;

public static class ProjectileComponentFactory
{
    private static IDictionary<ProjectileComponentEnum, Func<IProjectileComponent>> projectileCreators = new Dictionary<ProjectileComponentEnum, Func<IProjectileComponent>>();
    private static IDictionary<ProjectileComponentEnum, IProjectileComponent> projectileComponentInstances = new Dictionary<ProjectileComponentEnum, IProjectileComponent>();

    public static void AddCreator(ProjectileComponentEnum component, Func<IProjectileComponent> creator)
    {
        projectileCreators.Add(component, creator);
    }

    public static bool TryGet(ProjectileComponentEnum component, out IProjectileComponent projectileComponent)
    {
        if (projectileComponentInstances.TryGetValue(component, out projectileComponent)) {
            return true;
        }

        if (projectileCreators.TryGetValue(component, out var creator))
        {
            projectileComponent = creator();
            projectileComponentInstances.Add(component, projectileComponent);
            return true;
        }

        projectileComponent = null;
        return false;
    }
}