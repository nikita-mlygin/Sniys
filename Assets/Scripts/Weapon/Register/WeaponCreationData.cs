using System;
using UnityEngine;

public struct WeaponCreationData
{
    public object Data { get; set; }
    public Func<GameObject, ProjectileManager, object, IWeapon> WeaponCreator
    {
        get; set;
    }
}