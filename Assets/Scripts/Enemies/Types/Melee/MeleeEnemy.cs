using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : IEnemy
{
    public MeleeEnemy(GameObject enemyInstance, List<IEnemyComponent> components)
    {
        this.enemyInstance = enemyInstance;
        this.components = components;
    }

    public GameObject EnemyInstance => enemyInstance;
    public List<IEnemyComponent> ComponentList => components;


    private readonly GameObject enemyInstance;
    private readonly List<IEnemyComponent> components;
}
