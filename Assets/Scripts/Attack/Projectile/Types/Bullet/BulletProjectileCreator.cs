using System.Linq;
using UnityEngine;

public class BulletProjectileCreator : BaseProjectileCreator<BulletProjectileData>
{
    public BulletProjectileCreator(BulletProjectileData data) : base(data)
    {
    }

    public BulletProjectileCreator(string path) : base(path)
    {
    }

    public override IProjectile CreateProjectile(IWeapon weapon, Vector2 direction)
    {
        var instance = Object.Instantiate(data.Prefab, weapon.Owner.transform);

        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        instance.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        instance.transform.localScale *= data.Size;

        var deathTimer = instance.AddComponent<DeathTimer>();
        var bullet = instance.AddComponent<Bullet>();
        var team = instance.AddComponent<Team>();
        team.Name = weapon.Owner.GetComponent<Team>().Name;
        instance.AddComponent<DetectedObjectsList>();
        instance.AddComponent<DetectedAttackableList>();
        instance.AddComponent<ProjectileCollisionDetector>();

        deathTimer.DeathTime = Time.time + data.DeathTimeOffset;

        bullet.Direction = direction;
        bullet.Speed = data.Speed;
        bullet.Damage = data.Damage;
        bullet.Attacker = weapon.Owner;
        bullet.AttackerWeapon = weapon;

        return new BaseProjectile(instance, data.Components.Select(x =>
        {
            if (ProjectileComponentFactory.TryGet(x, out var projectileComponent))
            {
                return projectileComponent;
            }

            return null;
        }).ToList());
    }
}