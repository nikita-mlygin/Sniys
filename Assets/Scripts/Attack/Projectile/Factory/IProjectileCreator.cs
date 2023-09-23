using JetBrains.Annotations;
using UnityEngine;

public interface IProjectileCreator
{
    public IProjectile CreateProjectile(IWeapon weapon, Vector2 direction);
}