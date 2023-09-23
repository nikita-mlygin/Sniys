using UnityEngine;

public class EnemyComponentConfigure : MonoBehaviour
{
    private void Awake()
    {
        EnemyComponentFabric.AddComponentCreation(ComponentEnum.EnemyWithTargetInAttackDistanceMove, () => new EnemyWithTargetInAttackDistanceMoveComponent());
        EnemyComponentFabric.AddComponentCreation(ComponentEnum.IsAttackComponent, () => new EnemyGetIsAttackComponent());
        EnemyComponentFabric.AddComponentCreation(ComponentEnum.FindTarget, () => new FindTargetComponent());
    }
}