using System;
using System.Collections;
using System.Collections.Generic;

public static class EnemyComponentFabric
{
    private static IDictionary<EnemiesComponentEnum, Func<IEnemyComponent>> componentCreationDictionary = new Dictionary<EnemiesComponentEnum, Func<IEnemyComponent>>();
    private static IDictionary<EnemiesComponentEnum, IEnemyComponent> componentsInst = new Dictionary<EnemiesComponentEnum, IEnemyComponent>();

    public static void AddComponentCreation(EnemiesComponentEnum type, Func<IEnemyComponent> componentCreator)
    {
        componentCreationDictionary.Add(type, componentCreator);
    }

    public static bool TryGet(EnemiesComponentEnum type, out IEnemyComponent component)
    {
        if (componentsInst.TryGetValue(type, out component))
        {
            return true;
        }

        if (componentCreationDictionary.TryGetValue(type, out var creator))
        {
            component = creator();
            componentsInst.Add(type, component);
            return true;
        }

        return false;
    }
}