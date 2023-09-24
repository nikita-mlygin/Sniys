using UnityEngine;

public class MeleeAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<MeleeAttack>(out var component) && projectile.TryGetComponent<DetectedAttackableList>(out var attackableList))
        {
            for (int i = 0; i < attackableList.AttackableObjectList.Count; i++)
            {
                attackableList.AttackableObjectList[i].GetComponent<Attackable>().GetAttack(10, component.Weapon.Owner);
            }

            return true;
        }

        return true;
    }
}