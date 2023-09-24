using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private readonly IList<IProjectile> projectiles = new List<IProjectile>();

    public void AddProjectile(IProjectile projectile)
    {
        projectiles.Add(projectile);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            var projectile = projectiles[i];
            var instance = projectiles[i].Instance;

            for (int j = 0; j < projectile.Components.Count; j++)
            {
                if (!projectile.Components[j].Next(ref instance))
                {
                    projectiles.Remove(projectile);
                    break;
                }
            }
        }
    }
}
