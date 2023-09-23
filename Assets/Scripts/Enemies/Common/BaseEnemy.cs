using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : IEnemy
{
    private readonly GameObject enemyInstance;
    private readonly List<IEnemyComponent> componentList;

    public BaseEnemy(GameObject enemyInstance, List<IEnemyComponent> componentList)
    {
        this.enemyInstance = enemyInstance;
        this.componentList = componentList;
    }

    public GameObject EnemyInstance => enemyInstance;

    public List<IEnemyComponent> ComponentList => componentList;

    public void AddComponent(IEnemyComponent component, IEnemyComponent after = null)
    {
        if (after != null)
        {
            for (int i = 0; i < componentList.Count; i++)
            {
                if (componentList[i] == after)
                {
                    componentList.Insert(i, component);
                    return;
                }
            }
        }

        componentList.Add(component);
    }

    public void RemoveComponent(IEnemyComponent component)
    {
        throw new System.NotImplementedException();
    }
}