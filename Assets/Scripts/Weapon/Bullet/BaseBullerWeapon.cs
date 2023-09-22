using JetBrains.Annotations;
using UnityEngine;

public class BaseBulletWeapon : IWeapon
{
    public BaseBulletWeapon(GameObject weaponGameObject, GameObject owner, ProjectileManager projectileManager, BaseBulletCreationData data)
    {
        WeaponGameObject = weaponGameObject;
        Owner = owner;
        ProjectileManager = projectileManager;
        this.data = data;
    }

    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    private readonly BaseBulletCreationData data;

    public GameObject Attack(Vector2 direction)
    {
        var projectile = Object.Instantiate(data.BulletPrefab, Owner.transform);

        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);
        projectile.transform.localScale *= data.Size;

        var deathTimer = projectile.GetComponent<DeathTimer>();
        var bullet = projectile.GetComponent<Bullet>();

        deathTimer.DeathTime = Time.time + data.lifeTime;
        
        bullet.Direction = direction;
        bullet.Speed = data.Speed;
        bullet.Damage = data.Damage;

        return projectile;
    }
}