using UnityEngine;

public class ProjectileComponentFactoryConfigure : MonoBehaviour
{
    private void Awake()
    {
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.BulletMoveComponent, () => new BulletAttackComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.SplashComponent, () => new MeleeAttackComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.DeathTimer, () => new DeathTimerComponent());
    }
}