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
        var rb = enemyInstance.AddComponent<Rigidbody2D>();
        var target = enemyInstance.AddComponent<EnemyTarget>();
        var gettingAttacks = enemyInstance.AddComponent<EnemyGettingAttacks>();
        var attackable = enemyInstance.AddComponent<AttackableEnemy>();

        move.InitializeMaxSpeed(data.MaxSpeed);

        rb.gravityScale = 0;
        rb.freezeRotation = true;

        target.target = null;
        target.attackDistance = data.AttackDistance;

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
