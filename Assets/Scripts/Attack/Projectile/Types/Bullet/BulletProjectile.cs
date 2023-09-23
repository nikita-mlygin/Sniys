using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : BaseProjectile
{
    public BulletProjectile(GameObject instance, List<IProjectileComponent> components) : base(instance, components)
    {
    }
}