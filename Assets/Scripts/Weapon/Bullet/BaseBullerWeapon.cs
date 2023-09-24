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
        var reload = weaponGameObject.AddComponent<WeaponReload>();
        reload.ReloadTime = 1f / data.AttackPerSecond;
    }

    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    private readonly BaseBulletWeaponCreationData data;

    public IProjectile Attack(Vector2 direction)
    {
        if (this.WeaponGameObject.GetComponent<WeaponReload>().ReloadTime > Time.time)
        {
            return null;
        }

        if (ProjectileFactory.TryGet(ProjectileEnum.Bullet, this, direction, out var projectile))
        {
            this.WeaponGameObject.GetComponent<WeaponReload>().ReloadTime = Time.time + 1f / data.AttackPerSecond;

            return projectile;
        }

        throw new System.Exception("Projectile not found");
    }
}