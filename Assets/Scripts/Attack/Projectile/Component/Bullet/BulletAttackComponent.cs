using UnityEngine;

public class BulletAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (
            projectile.TryGetComponent<DetectedAttackableList>(out var enemies) && 
            projectile.TryGetComponent<Bullet>(out var bullet) &&
            enemies.AttackableObjectList.Count > 0)
        {
            enemies.AttackableObjectList[0].GetAttack(bullet.Damage, bullet.Attacker);
        }

        return true;
    }
}