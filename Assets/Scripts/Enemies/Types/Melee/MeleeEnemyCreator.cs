using System.Linq;
using UnityEngine;

public class MeleeEnemyCreator : BaseEnemyCreator<MeleeEnemyData>
{
    private readonly ProjectileManager projectileManager;

    public MeleeEnemyCreator(MeleeEnemyData data, ProjectileManager projectileManager) : base(data)
    {
        this.projectileManager = projectileManager;
    }

    public MeleeEnemyCreator(string path, ProjectileManager projectileManager) : base(path)
    {
        this.projectileManager = projectileManager;
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
        var weaponInventory = enemyInstance.AddComponent<WeaponInventory>();
        var attacker = enemyInstance.AddComponent<Attacker>();
        var team = enemyInstance.AddComponent<Team>();
        team.Name = "Enemies";

        attacker.projectileManager = this.projectileManager;

        if (WeaponFabric.TryCreateWeapon(data.PrimaryWeapon, enemyInstance, projectileManager, out var weapon))
        {
            weaponInventory.PrimaryWeapon = weapon;
        }

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
