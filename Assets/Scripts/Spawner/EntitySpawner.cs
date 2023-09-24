using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public float spawnTime;
    public Vector3 position;
    public EnemyManager enemyManager;

    private void Update()
    {
        if (spawnTime < Time.time)
        {
            spawnTime += 5;

            for (int i = 0; i < 10; i++)
            {
                if (EnemyFabric.TryCreate(EnemyEnum.Melee, position, out var enemy))
                {
                    enemyManager.AddEnemy(enemy);
                }
            }
        }
    }
}