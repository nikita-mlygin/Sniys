using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : IProjectile
{
    public BaseProjectile(GameObject instance, List<IProjectileComponent> components)
    {
        this.instance = instance;
        this.components = components;
    }

    public GameObject Instance => instance;
    public List<IProjectileComponent> Components => components;

    private readonly GameObject instance;
    private readonly List<IProjectileComponent> components;
}
