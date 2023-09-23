using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private IList<IEnemy> enemies = new List<IEnemy>();
    private IList<IEnemyComponent> components = new List<IEnemyComponent>();

    public void AddEnemy(IEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void AddComponent(IEnemyComponent component)
    {
        components.Add(component);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            var goEnemy = enemy.EnemyInstance;

            for (int j = 0; j < components.Count; j++)
            {
                if (!components[j].Next(ref goEnemy, out var isDelete))
                {
                    if (isDelete)
                    {
                        enemies.Remove(enemy);
                    }

                    break;
                }
            }
        }
    }
}