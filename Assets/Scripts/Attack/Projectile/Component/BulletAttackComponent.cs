using UnityEngine;

public class BulletAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<Bullet>(out var bullet))
        {
            projectile.GetComponent<Rigidbody2D>().MovePosition(
                (Vector2)projectile.transform.position + bullet.Speed * Time.fixedDeltaTime * bullet.Direction.normalized);
        }

        return true;
    }
}