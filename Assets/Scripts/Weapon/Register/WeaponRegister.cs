using UnityEngine;

public static class WeaponRegister
{
    public static void Register()
    {
        WeaponFabric.AddWeapon("Sword", new WeaponCreationData()
        {
            Data = new TestMeleeWeaponCreationData()
            {
                WeaponPrefab = Resources.Load("Prefabs/Attack/Melee/TestAttack", typeof(GameObject)) as GameObject
            },
            WeaponCreator = (GameObject owner, GameObject viewWeapon, ProjectileManager projectileManager, object data) =>
            {
                return new TestMeleeWeapon(viewWeapon, owner, projectileManager, ((TestMeleeWeaponCreationData)data).WeaponPrefab);
            }
        });

        WeaponFabric.AddWeapon("Pistol", new WeaponCreationData()
        {
            Data = new BaseBulletCreationData()
            {
                BulletPrefab = Resources.Load("Prefabs/Attack/Bullet/TestBullet", typeof(GameObject)) as GameObject
            },
            WeaponCreator = (GameObject owner, GameObject viewWeapon, ProjectileManager projectileManager, object data) =>
            {
                return new BaseBulletWeapon(viewWeapon, owner, projectileManager, ((BaseBulletCreationData)data).BulletPrefab);
            }
        });
    }
}