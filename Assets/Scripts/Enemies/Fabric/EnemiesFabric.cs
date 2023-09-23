using System.Collections.Generic;
using UnityEngine;

public static class EnemyFabric
{ 
    private static readonly IDictionary<EnemyEnum, IEnemyCreator> creatorDictionary = new Dictionary<EnemyEnum, IEnemyCreator>();

    public static void AddCreator(EnemyEnum enemy, IEnemyCreator creator)
    {
        creatorDictionary.Add(enemy, creator);
    }

    public static bool TryCreate(EnemyEnum enemyType, Vector3 position, out IEnemy enemy)
    {
        if (creatorDictionary.TryGetValue(enemyType, out var creator))
        {
            enemy = creator.CreateEnemy(position);

            return true;
        }

        enemy = null;
        return false;
    }
}