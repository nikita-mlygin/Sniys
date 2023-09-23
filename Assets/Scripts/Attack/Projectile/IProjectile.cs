using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    public GameObject Instance { get; }
    public List<IProjectileComponent> Components { get; }
}