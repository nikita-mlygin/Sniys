using UnityEngine;

public class EnemyComponentConfigure : MonoBehaviour
{
    private void Awake()
    {
        EnemyComponentFabric.AddComponentCreation(ComponentEnum.MoveComponent, () => new EnemyMoveComponent());
        EnemyComponentFabric.AddComponentCreation(ComponentEnum.IsAttackComponent, () => new EnemyGetIsAttackComponent());
    }
}