using System;
using UnityEngine;

public struct WeaponCreationData
{
    public object Data { get; set; }
    public Func<GameObject, GameObject, ProjectileManager, object, IWeapon> WeaponCreator
    {
        get; set;
    }
}