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
            direction.Normalize();
            moveController.SetDirection(direction);
        }

        isDelete = false;
        return true;
    }
}
