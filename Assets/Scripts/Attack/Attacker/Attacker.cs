using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    public ProjectileManager projectileManager;

    public void Attack(IWeapon weapon, Vector2 direction)
    {
        var attack = weapon.Attack(direction);

        if (attack == null)
        {
            return;
        }

        projectileManager.AddProjectile(attack);
    }
}
