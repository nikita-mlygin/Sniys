using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private readonly IList<GameObject> projectiles = new List<GameObject>();
    private readonly IList<IProjectileComponent> projectileComponents = new List<IProjectileComponent>();

    public void AddProjectileComponent(IProjectileComponent component)
    {
        projectileComponents.Add(component);
    }

    public void AddProjectile(GameObject projectile)
    {
        projectiles.Add(projectile);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            for (int j = 0; j < projectileComponents.Count; j++)
            {
                var projectile = projectiles[i];

                if (!projectileComponents[j].Next(ref projectile))
                {
                    projectiles.Remove(projectile);
                    break;
                }
            }
        }
    }
}
