using UnityEngine;

public static class WeaponRegister
{
    public static void Register()
    {
        var swordData = Resources.Load("Weapons/Sword");

        WeaponFabric.AddWeapon("Sword", swordData as TestMeleeWeaponCreationData, (owner, view, projectileManager, data) =>
        {
            return new TestMeleeWeapon(view, owner, projectileManager, data);
        });

        WeaponFabric.AddWeapon("Pistol", Resources.Load("Weapons/Pistol") as BaseBulletCreationData, (owner, view, projectileManager, data) =>
        {
            return new BaseBulletWeapon(view, owner, projectileManager, data);
        });
    }
}