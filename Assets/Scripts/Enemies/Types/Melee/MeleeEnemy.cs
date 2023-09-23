using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    public MeleeEnemy(GameObject enemyInstance, List<IEnemyComponent> components) : base(enemyInstance, components)
    {
    }
}
