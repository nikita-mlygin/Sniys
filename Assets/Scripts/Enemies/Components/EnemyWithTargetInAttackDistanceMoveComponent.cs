using System.ComponentModel.Design;
using UnityEngine;

public class EnemyWithTargetInAttackDistanceMoveComponent : IEnemyComponent
{
    public bool Next(ref GameObject enemy, out bool isDelete)
    {
        if (
            enemy.TryGetComponent<EnemyTarget>(out var target) &&
            enemy.TryGetComponent<MoveController>(out var moveController) &&
            target != null)
        {
            var direction = (target.target.transform.position - enemy.transform.position);

            if (target.attackDistance > Vector2.Distance(target.target.transform.position, enemy.transform.position))
            {
                if (enemy.TryGetComponent<Attacker>(out var attacker) && enemy.TryGetComponent<WeaponInventory>(out var weapons)) {
                    if (enemy == null)
                    {
                        isDelete = false;
                        return false;
                    }
                    
                    attacker.Attack(weapons.PrimaryWeapon, direction.normalized);
                }
            }

            direction.Normalize();
            moveController.SetDirection(direction);
        }

        isDelete = false;
        return true;
    }
}
