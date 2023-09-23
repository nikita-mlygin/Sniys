using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnemyManager : MonoBehaviour
{
    private IList<IEnemy> enemies = new List<IEnemy>();

    public void AddEnemy(IEnemy enemy)
    {
        enemies.Add(enemy);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            var goEnemy = enemy.EnemyInstance;
            var components = enemy.ComponentList;

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