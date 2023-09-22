using JetBrains.Annotations;
using UnityEngine;

public class BaseBulletWeapon : IWeapon
{
    public BaseBulletWeapon(GameObject weaponGameObject, GameObject owner, ProjectileManager projectileManager, GameObject bulletPrefab)
    {
        WeaponGameObject = weaponGameObject;
        Owner = owner;
        ProjectileManager = projectileManager;
        BulletPrefab = bulletPrefab;
    }

    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    public GameObject BulletPrefab { get; set; }

    public GameObject Attack(Vector2 direction)
    {
        var projectile = Object.Instantiate(BulletPrefab, Owner.transform);

        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        var deathTimer = projectile.GetComponent<DeathTimer>();
        var bullet = projectile.GetComponent<Bullet>();

        deathTimer.DeathTime = Time.time + 2;
        
        bullet.Direction = direction;
        bullet.Speed = 5f;
        bullet.Damage = 2;

        return projectile;
    }
}