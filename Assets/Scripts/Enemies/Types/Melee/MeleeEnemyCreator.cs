using System.Linq;
using UnityEngine;

public class MeleeEnemyCreator : BaseEnemyCreator<MeleeEnemyData>
{
    public MeleeEnemyCreator(MeleeEnemyData data) : base(data)
    {
    }

    public MeleeEnemyCreator(string path) : base(path)
    {
    }

    public override IEnemy CreateEnemy(Vector3 position)
    {
        var enemyInstance = GameObject.Instantiate(data.EnemyPrefab);
        enemyInstance.transform.position = position;

        var move = enemyInstance.AddComponent<MoveController>();
        move.InitializeMaxSpeed(data.MaxSpeed);

        var rb = enemyInstance.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;

        return new MeleeEnemy(enemyInstance, data.Components.Select(x =>
        {
            if (EnemyComponentFabric.TryGet(x, out var component))
            {
                return component;
            }

            return null;
        }).ToList());
    }
}
