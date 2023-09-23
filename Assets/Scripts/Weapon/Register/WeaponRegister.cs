using UnityEngine;

public static class WeaponRegister
{
    public static void Register()
    {
        var swordData = Resources.Load("Weapons/Sword");

        WeaponFabric.AddWeapon("Sword", swordData as TestMeleeWeaponCreationData, (owner, projectileManager, data) =>
        {
            var view = GameObject.Instantiate(data.WeaponViewPrefab, owner.transform);

            return new TestMeleeWeapon(view, owner, projectileManager, data);
        });

        WeaponFabric.AddWeapon("Pistol", Resources.Load("Weapons/Pistol") as BaseBulletCreationData, (owner, projectileManager, data) =>
        {
            var view = GameObject.Instantiate(data.WeaponViewPrefab, owner.transform);

            return new BaseBulletWeapon(view, owner, projectileManager, data);
        });
    }
}