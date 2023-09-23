using UnityEngine;

public class EnemyFabricConfigure : MonoBehaviour
{
    private void Awake()
    {
        EnemyFabric.AddCreator(EnemyEnum.Melee, new MeleeEnemyCreator("Enemies/Alien1"));
    }
}