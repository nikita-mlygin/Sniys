using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponFabric
{
    private static IDictionary<string, WeaponCreationData> weaponDictionary = new Dictionary<string, WeaponCreationData>();

    public static void AddWeapon(string name, WeaponCreationData weaponCreationData)
    {
        weaponDictionary.Add(name, weaponCreationData);
    }

    public static void AddWeapon<T>(string name, T weaponData, Func<GameObject, GameObject, ProjectileManager, T, IWeapon> creationFunction)
        where T : ScriptableObject
    {
        weaponDictionary.Add(name, new WeaponCreationData()
        {
            Data = weaponData,
            WeaponCreator = (GameObject owner, GameObject view, ProjectileManager projectileManager, object data) =>
            {
                return creationFunction(owner, view, projectileManager, (T)data);
            }
        });
    }

    public static bool TryCreateWeapon(string name, GameObject owner, GameObject weaponDisplay, ProjectileManager projectileManager, out IWeapon weapon)
    {
        if (weaponDictionary.TryGetValue(name, out var creationData))
        {
            weapon = creationData.WeaponCreator(owner, weaponDisplay, projectileManager, creationData.Data);

            return true;
        }

        weapon = default;
        return false;
    }
}