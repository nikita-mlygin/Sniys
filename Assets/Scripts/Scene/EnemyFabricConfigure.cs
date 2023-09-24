using UnityEngine;

public class EnemyFabricConfigure : MonoBehaviour
{
    [SerializeField]
    private ProjectileManager projectileManager;

    private void Awake()
    {
        EnemyFabric.AddCreator(EnemyEnum.Melee, new MeleeEnemyCreator("Enemies/Alien1", projectileManager));
    }
}