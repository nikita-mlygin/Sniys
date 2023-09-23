using JetBrains.Annotations;
using UnityEngine;

public class BaseBulletWeapon : IWeapon
{
    public BaseBulletWeapon(GameObject weaponGameObject, GameObject owner, ProjectileManager projectileManager, BaseBulletWeaponCreationData data)
    {
        WeaponGameObject = weaponGameObject;
        Owner = owner;
        ProjectileManager = projectileManager;
        this.data = data;
    }

    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    private readonly BaseBulletWeaponCreationData data;

    public IProjectile Attack(Vector2 direction)
    {
        if (ProjectileFactory.TryGet(ProjectileEnum.Bullet, this, direction, out var projectile))
        {
            return projectile;
        }

        throw new System.Exception("Projectile not found");
    }
}