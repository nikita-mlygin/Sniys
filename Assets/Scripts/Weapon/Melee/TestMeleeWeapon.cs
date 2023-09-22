using UnityEditor.Rendering;
using UnityEngine;

public class TestMeleeWeapon : IWeapon
{
    public TestMeleeWeapon(GameObject weaponGameObject, GameObject owner, ProjectileManager projectileManager, TestMeleeWeaponCreationData data)
    {
        WeaponGameObject = weaponGameObject;
        Owner = owner;
        ProjectileManager = projectileManager;
        this.creationData = data;
    }

    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    public TestMeleeWeaponCreationData creationData;

    public GameObject Attack(Vector2 direction)
    {
        var projectile = Object.Instantiate(creationData.AttackPrefab, Owner.transform);

        var melee = projectile.GetComponent<MeleeAttack>();
        var deathTimer = projectile.GetComponent<DeathTimer>();

        melee.Attacker = Owner;

        melee.Direction = direction;
        melee.Damage = creationData.Damage;
        melee.Weapon = WeaponGameObject;
        deathTimer.DeathTime = Time.time + 1f / creationData.AttackPerSecond;

        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);


        var animator = WeaponGameObject.GetComponent<Animator>();
        animator.Play("Attack", 0, 1);
        animator.speed = 1f * creationData.AttackPerSecond;

        WeaponGameObject.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        return projectile;
    }
}