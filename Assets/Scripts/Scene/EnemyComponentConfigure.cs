using UnityEngine;

public class EnemyComponentConfigure : MonoBehaviour
{
    private void Awake()
    {
        EnemyComponentFabric.AddComponentCreation(EnemiesComponentEnum.EnemyWithTargetInAttackDistanceMove, () => new EnemyWithTargetInAttackDistanceMoveComponent());
        EnemyComponentFabric.AddComponentCreation(EnemiesComponentEnum.IsAttackComponent, () => new EnemyGetIsAttackComponent());
        EnemyComponentFabric.AddComponentCreation(EnemiesComponentEnum.FindTarget, () => new FindTargetComponent());
    }
}