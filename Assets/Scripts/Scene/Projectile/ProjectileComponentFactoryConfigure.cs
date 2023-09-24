using UnityEngine;

public class ProjectileComponentFactoryConfigure : MonoBehaviour
{
    private void Awake()
    {
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.BulletMoveComponent, () => new BulletAttackMoveComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.SplashComponent, () => new MeleeAttackComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.DeathTimer, () => new DeathTimerComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.DetectAttack, () => new DetectAttackComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.BulletDetect, () => new BulletDetectComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.BulletAttack, () => new BulletAttackComponent());
        ProjectileComponentFactory.AddCreator(ProjectileComponentEnum.Reload, () => new ReloadWeaponComponent());
    }
}