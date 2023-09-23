using UnityEngine;

public class FindTargetComponent : IEnemyComponent
{
    public bool Next(ref GameObject enemy, out bool isDelete)
    {
        if (enemy.TryGetComponent<EnemyTarget>(out var target))
        {
            if (target.target == null)
            {
                target.target = GameObject.FindGameObjectsWithTag("Player")[0];
            }
        }

        isDelete = false;
        return true;
    }
}