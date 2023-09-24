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

    public IProjectile Attack(Vector2 direction)
    {
        if (ProjectileFactory.TryGet(ProjectileEnum.Splash, this, direction, out var projectile)) {
            return projectile;
        }

        return null;
    }
}