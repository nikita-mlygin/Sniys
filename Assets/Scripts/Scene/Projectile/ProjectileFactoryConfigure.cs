using UnityEngine;

public class ProjectileFactoryConfigure : MonoBehaviour
{
    private void Awake()
    {
        ProjectileFactory.AddCreator(ProjectileEnum.Bullet, new BulletProjectileCreator("Projectiles/Bullet1"));
        ProjectileFactory.AddCreator(ProjectileEnum.Splash, new SplashProjectileCreator("Projectiles/Splash1"));
    }
}