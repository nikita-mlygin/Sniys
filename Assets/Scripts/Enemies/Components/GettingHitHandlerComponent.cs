using UnityEngine;

public class GettingHitHandlerComponent : IEnemyComponent
{
    public bool Next(ref GameObject enemy, out bool isDelete)
    {
        if (enemy.TryGetComponent<EnemyGettingAttacks>(out var gettingAttacks) && gettingAttacks.Attacks.Count > 0)
        {
            Object.Destroy(enemy);
            isDelete = true;
            return false;
        }

        isDelete = false;
        return true;
    }
}