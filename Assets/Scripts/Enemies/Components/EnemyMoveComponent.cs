using UnityEngine;

public class EnemyMoveComponent : IEnemyComponent
{
    public bool Next(ref GameObject enemy, out bool isDelete)
    {
        if (enemy.TryGetComponent<EnemyAttack>(out var component) && component.enabled)
        {
            if (enemy.TryGetComponent<MoveController>(out var aboba))
            {
                aboba.SetSpeed(0);
            }

            isDelete = false;
            return true;
        }
        else if (enemy.TryGetComponent<MoveController>(out var moveController))
        {
            moveController.SetSpeed(3f);

            if (enemy.TryGetComponent<EnemyTarget>(out var target))
            {
                var direction = (target.target.transform.position - enemy.transform.position);

                direction.Normalize();

                moveController.SetDirection(direction);
            }
        }

        isDelete = false;
        return true;
    }
}
