using System.Linq;
using UnityEngine;

class SplashProjectileCreator : BaseProjectileCreator<SplashProjectileData>
{
    public SplashProjectileCreator(SplashProjectileData data) : base(data)
    {
    }

    public SplashProjectileCreator(string path) : base(path)
    {
    }

    public override IProjectile CreateProjectile(IWeapon weapon, Vector2 direction)
    {
        var instance = GameObject.Instantiate(data.SplashPrefab, weapon.Owner.transform);

        var deathTimer = instance.AddComponent<DeathTimer>();
        deathTimer.DeathTime = Time.time + 1f / data.AttackPerSecond;

        var team = instance.AddComponent<Team>();
        team.Name = weapon.Owner.GetComponent<Team>().Name;

        var melee = instance.AddComponent<MeleeAttack>();

        melee.Direction = direction;
        melee.Damage = 10;
        melee.Weapon = weapon;

        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        instance.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        var animator = weapon.WeaponGameObject.GetComponent<Animator>();
        animator.Play("Attack", 0, 1);
        animator.speed = 1f * data.AttackPerSecond;

        weapon.WeaponGameObject.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);


        instance.AddComponent<ProjectileCollisionDetector>();
        instance.AddComponent<ProjectileCollisionDetector>();
        instance.AddComponent<DetectedObjectsList>();
        instance.AddComponent<DetectedAttackableList>();

        //var projectile = Object.Instantiate(creationData.AttackPrefab, Owner.transform);

        //var melee = projectile.GetComponent<MeleeAttack>();
        //var deathTimer = projectile.GetComponent<DeathTimer>();

        //melee.Attacker = Owner;

        //melee.Direction = direction;
        //melee.Damage = creationData.Damage;
        //melee.Weapon = WeaponGameObject;
        //deathTimer.DeathTime = Time.time + 1f / creationData.AttackPerSecond;

        //float angleRadians = Mathf.Atan2(direction.y, direction.x);
        //float angleDegrees = angleRadians * Mathf.Rad2Deg;

        //projectile.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);


        //var animator = WeaponGameObject.GetComponent<Animator>();
        //animator.Play("Attack", 0, 1);
        //animator.speed = 1f * creationData.AttackPerSecond;

        //WeaponGameObject.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        return new BaseProjectile(instance, data.Components.Select(x =>
        {
            if (ProjectileComponentFactory.TryGet(x, out var component))
            {
                return component;
            }

            return null;
        }).ToList());
    }
}