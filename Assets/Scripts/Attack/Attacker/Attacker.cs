using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    private ProjectileManager projectileManager;

    public void Attack(IWeapon weapon, Vector2 direction)
    {
        var attack = weapon.Attack(direction);

        projectileManager.AddProjectile(attack);
    }
}
