using UnityEngine;

public interface IWeapon
{
    public GameObject WeaponGameObject { get; set; }
    public GameObject Owner { get; set; }
    public ProjectileManager ProjectileManager { get; set; }

    public GameObject Attack(Vector2 direction);
}