using UnityEditor.Rendering;
using UnityEngine;

public class TestMeleeWeapon : IWeapon
{
    public TestMeleeWeapon(GameObject weaponGameObject, GameObject owner, ProjectileManager projectileManager, GameObject attackPrefab)
    {
        WeaponGameObject = weaponGameObject;
        Owner = owner;
        ProjectileManager = projectileManager;
        AttackPrefab = attackPrefab;
    }

    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    public GameObject AttackPrefab { get; set; }

    public GameObject Attack(Vector2 direction)
    {
        var projectile = Object.Instantiate(AttackPrefab, Owner.transform);

        var melee = projectile.GetComponent<MeleeAttack>();
        var deathTimer = projectile.GetComponent<DeathTimer>();

        melee.Attacker = Owner;
        melee.Direction = direction;
        deathTimer.DeathTime = Time.time + 0.3f;

        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        return projectile;
    }
}