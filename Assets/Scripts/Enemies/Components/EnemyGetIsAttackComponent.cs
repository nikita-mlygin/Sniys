using UnityEngine;

public class EnemyGetIsAttackComponent : IEnemyComponent
{
    public bool Next(ref GameObject enemy, out bool isDelete)
    {
        if (enemy.TryGetComponent<EnemyTarget>(out var target))
        {
            var distance = Vector2.Distance(target.target.transform.position, enemy.transform.position);

            if (distance < target.attackDistance)
            {
                if (enemy.TryGetComponent<EnemyAttack>(out var attack))
                {
                    attack.enabled = true;
                } else
                {
                    enemy.AddComponent<EnemyAttack>();
                }
            } else
            {
                if (enemy.TryGetComponent<EnemyAttack>(out var attack))
                {
                    attack.enabled = false;
                }
            }
        } 

        isDelete = false;
        return true;
    }
}
