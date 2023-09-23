using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private IList<GameObject> enemies = new List<GameObject>();
    private IList<IEnemyComponent> components = new List<IEnemyComponent>();

    public void AddEnemy(GameObject enemy)
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

            for (int j = 0; j < components.Count; j++)
            {
                if (!components[j].Next(ref enemy, out var isDelete))
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