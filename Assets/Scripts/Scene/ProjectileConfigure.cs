using UnityEngine;

public class ProjectileConfigure : MonoBehaviour
{
    private void Start()
    {
        var projectileManager = this.GetComponent<ProjectileManager>();

        projectileManager.AddProjectileComponent(new MeleeDeathTimerComponent());
        projectileManager.AddProjectileComponent(new DeathTimerComponent());
        projectileManager.AddProjectileComponent(new BulletAttackComponent());
        projectileManager.AddProjectileComponent(new MeleeAttackComponent());
    }
}
